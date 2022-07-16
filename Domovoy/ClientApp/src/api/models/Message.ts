/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApplicationUser } from './ApplicationUser';
import type { Chat } from './Chat';

export type Message = {
    id?: number;
    chatId?: number;
    chat?: Chat;
    text?: string | null;
    sentAt?: string;
    authorId?: number;
    author?: ApplicationUser;
};