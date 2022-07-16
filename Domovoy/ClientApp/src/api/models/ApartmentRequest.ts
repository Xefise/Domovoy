/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { ApplicationUser } from './ApplicationUser';

export type ApartmentRequest = {
    id?: number;
    additionalContacts?: string | null;
    requester?: ApplicationUser;
    requesterId?: number;
    apartment?: Apartment;
    apartmentId?: number;
};