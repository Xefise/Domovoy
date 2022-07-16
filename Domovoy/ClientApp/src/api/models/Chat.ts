/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentHouse } from './ApartmentHouse';
import type { ApplicationUser } from './ApplicationUser';
import type { Message } from './Message';

export type Chat = {
    id?: number;
    name?: string | null;
    apartmentHouseId?: number | null;
    apartmentHouse?: ApartmentHouse;
    administratorId?: number | null;
    administrator?: ApplicationUser;
    users?: Array<ApplicationUser> | null;
    messages?: Array<Message> | null;
};