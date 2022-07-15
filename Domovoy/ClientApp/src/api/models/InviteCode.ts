/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';

export type InviteCode = {
    id?: number;
    code?: string | null;
    apartment?: Apartment;
};