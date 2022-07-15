/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentState } from './ApartmentState';
import type { ApartmentType } from './ApartmentType';

export type SerachFilters = {
    city?: string | null;
    apartmentType?: ApartmentType;
    apartmentState?: ApartmentState;
    costMin?: number;
    costMax?: number;
    roomCountMin?: number;
    roomCountMax?: number;
};