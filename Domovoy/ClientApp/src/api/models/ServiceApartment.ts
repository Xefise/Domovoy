/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { Service } from './Service';

export type ServiceApartment = {
    id?: number;
    service?: Service;
    serviceId?: number;
    apartment?: Apartment;
    apartmentId?: number;
};