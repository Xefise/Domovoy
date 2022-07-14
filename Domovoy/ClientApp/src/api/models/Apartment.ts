/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUser } from './ApplicationUser';
import type { HouseEntrance } from './HouseEntrance';

export type Apartment = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
    /**
     * В кв.м.
     */
    area?: number;
    tenants?: Array<ApplicationUser> | null;
    owner?: ApplicationUser;
    tenantsWhoMainThis?: Array<ApplicationUser> | null;
    cost?: number | null;
    houseEntrance?: HouseEntrance;
};