import { Injectable } from '@angular/core';

import { Trx } from '@shared/models';

import { ModalController } from '../modal/modal.controller';
import { AlertComponent, Button, Input } from './template/alert.component';

export interface SharedAlertOptions {
    title?: string | Trx;
    message?: string | Trx;
    focusFirst?: boolean;
    handler?: (result?: any) => Promise<boolean>;
}

export interface AlertOptions extends SharedAlertOptions {
    buttons?: Button[];
    inputs?: Input[];
}

export interface ConfirmOptions extends SharedAlertOptions {
    confirmBtn?: Button;
    cancelBtn?: Button;
}

@Injectable({
    providedIn: 'root',
})
export class AlertController {
    constructor(private modalCtrl: ModalController) {}

    async alert(title: string | Trx, message: string | Trx, closeText: string) {
        await this.create({
            title,
            message,
            buttons: [
                {
                    text: closeText,
                    role: 'submit',
                    colour: 'primary',
                    className: 'mx-a',
                },
            ],
        });
    }

    async confirm(options: ConfirmOptions): Promise<boolean> {
        const confirmBtn = options.confirmBtn || {
            text: 'Confirm',
            role: 'submit',
        };

        const cancelBtn = options.cancelBtn || {
            text: 'Cancel',
            role: 'cancel',
        };

        const result = await this.create({
            title: options.title,
            message: options.message,
            buttons: [
                {
                    text: cancelBtn.text,
                    role: 'cancel',
                    colour: cancelBtn.colour,
                    className: 'mr-a',
                },
                {
                    text: confirmBtn.text,
                    role: 'submit',
                    colour: confirmBtn.colour || 'primary',
                    className: 'ml-a',
                },
            ],
            focusFirst: options.focusFirst,
            handler: options.handler,
        });

        return result !== null;
    }

    create(options: AlertOptions) {
        const modal = this.modalCtrl.add(new Date().toString(), AlertComponent, {
            title: options.title,
            message: options.message,
            inputs: options.inputs,
            buttons: options.buttons,
            focusFirst: options.focusFirst,
        });

        return modal.present({ dismissWhen: options.handler });
    }
}
