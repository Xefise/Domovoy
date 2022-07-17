/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUser } from './ApplicationUser';
import type { UserServiceType } from './UserServiceType';

export type UserService = {
    userMustHaveAnApartment?: boolean;
    type?: UserServiceType;
    id?: number;
    name?: string | null;
    serivceProvider?: ApplicationUser;
};