/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUser } from './ApplicationUser';
import type { Service } from './Service';

export type ServiceUser = {
    id?: number;
    service?: Service;
    serviceId?: number;
    applicationUser?: ApplicationUser;
    applicationUserId?: number;
};