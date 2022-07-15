/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentState } from './ApartmentState';
import type { ApartmentType } from './ApartmentType';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';
import type { HouseEntranceViewModel } from './HouseEntranceViewModel';

export type ApartmentViewModel = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
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
    tenants?: Array<ApplicationUserViewModel> | null;
    owner?: ApplicationUserViewModel;
    tenantsWhoMainThis?: Array<ApplicationUserViewModel> | null;
    houseEntrance?: HouseEntranceViewModel;
};