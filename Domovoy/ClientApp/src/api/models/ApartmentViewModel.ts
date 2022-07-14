/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

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
    tenants?: Array<ApplicationUserViewModel> | null;
    owner?: ApplicationUserViewModel;
    tenantsWhoMainThis?: Array<ApplicationUserViewModel> | null;
    cost?: number | null;
    houseEntrance?: HouseEntranceViewModel;
};