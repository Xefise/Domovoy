/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Service } from './Service';

export type ServicePaymentInvoice = {
    id?: number;
    serviceId?: number;
    service?: Service;
    amount?: number;
    check?: string | null;
    isPaid?: boolean;
    repaymentTime?: string;
};