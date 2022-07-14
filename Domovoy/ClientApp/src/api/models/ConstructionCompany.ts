/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouse } from './ApartmentHouse';
import type { ApplicationUser } from './ApplicationUser';

export type ConstructionCompany = {
    id?: number;
    name?: string | null;
    employees?: Array<ApplicationUser> | null;
    /**
     * If ConstructionCompanyAdmin
     */
    apartmentHouses?: Array<ApartmentHouse> | null;
};