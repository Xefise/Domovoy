/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Service } from './Service';

export type PermanentService = {
    id?: number;
    service?: Service;
    serviceId?: number;
    autoPay?: boolean;
    period?: string | null;
};