/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { AparmentState } from './AparmentState';
import type { AparmentType } from './AparmentType';

export type ApartmentCreate = {
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
    aparmentType?: AparmentType;
    aparmentState?: AparmentState;
    cost?: number | null;
    description?: string | null;
    houseEntranceId?: number;
};