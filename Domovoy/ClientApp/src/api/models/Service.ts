/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { PermanentService } from './PermanentService';

export type Service = {
    id?: number;
    name?: string | null;
    isActive?: boolean;
    createDate?: string;
    closeDate?: string;
    check?: string | null;
    hasPaid?: boolean;
    apartment?: Apartment;
    apartmentId?: number;
    permanentService?: PermanentService;
    permanentServiceId?: number | null;
};