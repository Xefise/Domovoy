/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { PermanentService } from './PermanentService';
import type { ServiceApartment } from './ServiceApartment';
import type { ServicePaymentInvoice } from './ServicePaymentInvoice';
import type { ServiceUser } from './ServiceUser';

export type Service = {
    id?: number;
    name?: string | null;
    isActive?: boolean;
    createDate?: string;
    closeDate?: string | null;
    servicePaymentInvoices?: Array<ServicePaymentInvoice> | null;
    readonly debt?: number;
    permanentService?: PermanentService;
    permanentServiceId?: number | null;
    serviceUser?: ServiceUser;
    serviceUserId?: number | null;
    serviceApartment?: ServiceApartment;
    serviceApartmentId?: number | null;
};