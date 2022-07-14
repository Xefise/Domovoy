/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouse } from './ApartmentHouse';
import type { ConstructionCompany } from './ConstructionCompany';

export type ResidentialComplex = {
    id?: number;
    name?: string | null;
    constructionCompany?: ConstructionCompany;
    apartmentHouses?: Array<ApartmentHouse> | null;
};