/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ConstructionCompanyViewModel } from './ConstructionCompanyViewModel';

export type ResidentialComplexViewModel = {
    id?: number;
    name?: string | null;
    constructionCompany?: ConstructionCompanyViewModel;
};