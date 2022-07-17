/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouse } from './ApartmentHouse';
import type { ApplicationUser } from './ApplicationUser';
import type { InformerServiceType } from './InformerServiceType';

export type InformerService = {
    scopeHouses?: Array<ApartmentHouse> | null;
    type?: InformerServiceType;
    id?: number;
    name?: string | null;
    serivceProvider?: ApplicationUser;
};