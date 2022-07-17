/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouse } from './ApartmentHouse';
import type { ApartmentServiceType } from './ApartmentServiceType';
import type { ApplicationUser } from './ApplicationUser';

export type ApartmentService = {
    scopeHouses?: Array<ApartmentHouse> | null;
    type?: ApartmentServiceType;
    id?: number;
    name?: string | null;
    serivceProvider?: ApplicationUser;
};