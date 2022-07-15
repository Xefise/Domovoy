/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AparmentState } from './AparmentState';
import type { AparmentType } from './AparmentType';
import type { ApplicationUser } from './ApplicationUser';
import type { HouseEntrance } from './HouseEntrance';
import type { InviteCode } from './InviteCode';

export type Apartment = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
    roomCount?: number;
    /**
     * В кв.м.
     */
    area?: number;
    /**
     * В кв.м.
     */
    livingArea?: number;
    /**
     * В кв.м.
     */
    areaWithoutBalconies?: number;
    aparmentType?: AparmentType;
    aparmentState?: AparmentState;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUser> | null;
    owner?: ApplicationUser;
    tenantsWhoMainThis?: Array<ApplicationUser> | null;
    inviteCodes?: Array<InviteCode> | null;
    houseEntrance?: HouseEntrance;
    houseEntranceId?: number;
};