/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Address } from './Address';
import type { ApartmentService } from './ApartmentService';
import type { HouseEntrance } from './HouseEntrance';
import type { InformerService } from './InformerService';
import type { ResidentialComplex } from './ResidentialComplex';

export type ApartmentHouse = {
    id?: number;
    address?: Address;
    houseEntrances?: Array<HouseEntrance> | null;
    residentialComplex?: ResidentialComplex;
    residentialComplexId?: number;
    apartmentServices?: Array<ApartmentService> | null;
    informerServices?: Array<InformerService> | null;
};