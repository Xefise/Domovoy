/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Address } from './Address';
import type { ConstructionCompanyViewModel } from './ConstructionCompanyViewModel';

export type ApartmentHouseViewModel = {
    id?: number;
    address?: Address;
    constructionCompany?: ConstructionCompanyViewModel;
};