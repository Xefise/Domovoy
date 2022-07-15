/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AparmentState } from './AparmentState';
import type { AparmentType } from './AparmentType';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';
import type { HouseEntranceViewModel } from './HouseEntranceViewModel';
import type { Informer } from './Informer';
import type { Service } from './Service';

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
    aparmentType?: AparmentType;
    aparmentState?: AparmentState;
    cost?: number | null;
    description?: string | null;
    tenants?: Array<ApplicationUserViewModel> | null;
    owner?: ApplicationUserViewModel;
    tenantsWhoMainThis?: Array<ApplicationUserViewModel> | null;
    services?: Array<Service> | null;
    informers?: Array<Informer> | null;
    houseEntrance?: HouseEntranceViewModel;
};