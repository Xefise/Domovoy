/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

export type ApartmentPut = {
    id?: number;
    apartmentNumber?: number;
    floor?: number;
    /**
     * В кв.м.
     */
    area?: number;
    isSelling?: boolean;
    cost?: number | null;
    description?: string | null;
};