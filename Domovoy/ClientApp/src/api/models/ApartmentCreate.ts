/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

export type ApartmentCreate = {
    apartmentNumber?: number;
    floor?: number;
    /**
     * В кв.м.
     */
    area?: number;
    isSelling?: boolean;
    cost?: number | null;
    description?: string | null;
    houseEntranceId?: number;
};