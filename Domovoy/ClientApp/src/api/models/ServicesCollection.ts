/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentService } from './ApartmentService';
import type { InformerService } from './InformerService';
import type { UserService } from './UserService';

export type ServicesCollection = {
    userServices?: Array<UserService> | null;
    apartmentServices?: Array<ApartmentService> | null;
    informerServices?: Array<InformerService> | null;
};