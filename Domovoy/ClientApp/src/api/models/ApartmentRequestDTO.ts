/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentViewModel } from './ApartmentViewModel';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';

export type ApartmentRequestDTO = {
    id?: number;
    additionalContacts?: string | null;
    requester?: ApplicationUserViewModel;
    apartment?: ApartmentViewModel;
};