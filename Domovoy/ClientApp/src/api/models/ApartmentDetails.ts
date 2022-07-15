/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUserViewModel } from './ApplicationUserViewModel';

export type ApartmentDetails = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
    /**
     * В кв.м.
     */
    area?: number;
    isSelling?: boolean;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUserViewModel> | null;
    owner?: ApplicationUserViewModel;
    tenantsWhoMainThis?: Array<ApplicationUserViewModel> | null;
};