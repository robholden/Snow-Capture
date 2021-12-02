import { buildQueryString, pascalToScores } from '@shared/functions';
import { SMap } from '@shared/models';

export type OrderByDirection = 'asc' | 'desc';

export class PageRequest {
    public page: number = 1;
    public pageSize: number = 25;

    constructor(public orderBy: string = '', public orderDir: OrderByDirection = 'desc') {
        this.orderBy = pascalToScores(orderBy);
    }

    static fromPageSize(size: number): PageRequest {
        const request = new PageRequest();
        request.pageSize = size;
        return request;
    }
}

export function pageRequestFromQueryString(qparams: SMap<string>, def?: PageRequest) {
    def = def || new PageRequest();
    const pager = buildQueryString<PageRequest>(qparams, { pageSize: 'number', page: 'number', orderDir: 'string', orderBy: 'string' }, def);

    if (!pager.orderBy) pager.orderDir = def.orderDir;

    return pager;
}
