/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentService } from './ApartmentService';
import type { ApartmentViewModel } from './ApartmentViewModel';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';

export type ApartmentServiceServiceEntryDTO = {
    id?: number;
    service?: ApartmentService;
    data?: string | null;
    completed?: boolean;
    user?: ApplicationUserViewModel;
    apartment?: ApartmentViewModel;
};