/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { ApartmentHouse } from './ApartmentHouse';

export type HouseEntrance = {
    id?: number;
    enranceNumber?: number;
    apartmentHouse?: ApartmentHouse;
    apartments?: Array<Apartment> | null;
};