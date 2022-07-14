/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Address } from './Address';
import type { ResidentialComplexViewModel } from './ResidentialComplexViewModel';

export type ApartmentHouseViewModel = {
    id?: number;
    address?: Address;
    residentialComplex?: ResidentialComplexViewModel;
};