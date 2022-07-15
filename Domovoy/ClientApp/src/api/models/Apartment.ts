/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AparmentState } from './AparmentState';
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
    aparmentState?: AparmentState;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUser> | null;
    owner?: ApplicationUser;
    tenantsWhoMainThis?: Array<ApplicationUser> | null;
    houseEntrance?: HouseEntrance;
    houseEntranceId?: number;
};