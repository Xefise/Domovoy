/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentState } from './ApartmentState';
import type { ApartmentType } from './ApartmentType';
import type { ApplicationUser } from './ApplicationUser';
import type { HouseEntrance } from './HouseEntrance';
import type { Informer } from './Informer';
import type { InviteCode } from './InviteCode';
import type { ServiceApartment } from './ServiceApartment';

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
    apartmentType?: ApartmentType;
    apartmentState?: ApartmentState;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUser> | null;
    owner?: ApplicationUser;
    tenantsWhoMainThis?: Array<ApplicationUser> | null;
    inviteCodes?: Array<InviteCode> | null;
    serviceApartments?: Array<ServiceApartment> | null;
    informers?: Array<Informer> | null;
    houseEntrance?: HouseEntrance;
    houseEntranceId?: number;
};