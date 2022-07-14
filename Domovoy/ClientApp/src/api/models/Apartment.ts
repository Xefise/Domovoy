/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUser } from './ApplicationUser';
import type { HouseEntrance } from './HouseEntrance';

export type Apartment = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
    roomCount?: number;
    /**
     * В кв.м.
     */
    area?: number;
    isSelling?: boolean;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUser> | null;
    owner?: ApplicationUser;
    tenantsWhoMainThis?: Array<ApplicationUser> | null;
    houseEntrance?: HouseEntrance;
};