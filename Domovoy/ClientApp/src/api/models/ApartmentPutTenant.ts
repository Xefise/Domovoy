/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentState } from './ApartmentState';

export type ApartmentPutTenant = {
    id?: number;
    apartmentState?: ApartmentState;
    cost?: number | null;
    description?: string | null;
};