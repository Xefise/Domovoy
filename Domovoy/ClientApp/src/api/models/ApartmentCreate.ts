/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AparmentState } from './AparmentState';

export type ApartmentCreate = {
    apartmentNumber?: number;
    floor?: number;
    /**
     * В кв.м.
     */
    area?: number;
    aparmentState?: AparmentState;
    cost?: number | null;
    description?: string | null;
    houseEntranceId?: number;
};