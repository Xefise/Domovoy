/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouseDetails } from './ApartmentHouseDetails';

export type ResidentialComplexDetails = {
    id?: number;
    name?: string | null;
    apartmentHouses?: Array<ApartmentHouseDetails> | null;
};