/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUserType } from './ApplicationUserType';

export type ApplicationUserViewModel = {
    id?: number;
    userName?: string | null;
    firstName?: string | null;
    lastName?: string | null;
    patronymic?: string | null;
    email?: string | null;
    type: ApplicationUserType;
};