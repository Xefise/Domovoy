/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentDetails } from './ApartmentDetails';

export type HouseEntranceDetails = {
    id?: number;
    enranceNumber?: number;
    apartments?: Array<ApartmentDetails> | null;
};