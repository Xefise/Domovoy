/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Address } from './Address';
import type { ConstructionCompany } from './ConstructionCompany';
import type { HouseEntrance } from './HouseEntrance';

export type ApartmentHouse = {
    id?: number;
    address?: Address;
    houseEntrances?: Array<HouseEntrance> | null;
    constructionCompany?: ConstructionCompany;
};