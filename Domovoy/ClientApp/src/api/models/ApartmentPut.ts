/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentState } from './ApartmentState';
import type { ApartmentType } from './ApartmentType';

export type ApartmentPut = {
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
    apartmentType?: ApartmentType;
    apartmentState?: ApartmentState;
    cost?: number | null;
    description?: string | null;
};