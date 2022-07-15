/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUserViewModel } from './ApplicationUserViewModel';
import type { ResidentialComplexDetails } from './ResidentialComplexDetails';

export type ConstructionCompanyDetails = {
    id?: number;
    name?: string | null;
    employees?: Array<ApplicationUserViewModel> | null;
    residentialComplexes?: Array<ResidentialComplexDetails> | null;
};