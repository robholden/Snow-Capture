import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { CustomError, Trx } from '@shared/models';
import { UserService } from '@shared/services/identity/user.service';
import { AuthState } from '@shared/storage';

@Component({
    selector: 'sc-confirm-email',
    templateUrl: './confirm-email.page.html',
    styleUrls: ['./confirm-email.page.scss'],
})
export class ConfirmEmailPage implements OnInit {
    valid: boolean = null;
    error: Trx;

    constructor(private activatedRoute: ActivatedRoute, private userService: UserService, private authState: AuthState) {
        const key = this.activatedRoute.snapshot.params['key'];
        this.confirmEmail(key);
    }

    ngOnInit() {}

    // Checks given key key is valid
    //
    async confirmEmail(key: string) {
        // Quit if key is null
        if (!key) {
            return;
        }

        // Verify the key with the server
        const resp = await this.userService.confirmEmail(key);

        // Stop if response is an exception
        if (resp instanceof CustomError) {
            this.error = resp;
            this.valid = false;
            return;
        }

        // Email confirmed successfully
        if (this.authState.user) this.authState.updateUser('emailConfirmed', true);

        this.valid = true;
    }
}
