/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { EventInformer } from './EventInformer';

export type ActiveSession = {
    id?: number;
    eventInformer?: EventInformer;
    eventInformerId?: number;
    start?: string;
    end?: string;
    comment?: string | null;
    readonly duration?: string;
};