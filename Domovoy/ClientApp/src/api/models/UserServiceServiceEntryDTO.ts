/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentViewModel } from './ApartmentViewModel';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';
import type { UserService } from './UserService';

export type UserServiceServiceEntryDTO = {
    id?: number;
    service?: UserService;
    data?: string | null;
    completed?: boolean;
    user?: ApplicationUserViewModel;
    apartment?: ApartmentViewModel;
};