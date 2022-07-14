/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Address } from './Address';
import type { HouseEntrance } from './HouseEntrance';
import type { ResidentialComplex } from './ResidentialComplex';

export type ApartmentHouse = {
    id?: number;
    address?: Address;
    houseEntrances?: Array<HouseEntrance> | null;
    residentialComplex?: ResidentialComplex;
};