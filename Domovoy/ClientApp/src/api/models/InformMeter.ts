/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Informer } from './Informer';

export type InformMeter = {
    id?: number;
    informer?: Informer;
    informertId?: number;
    count?: number;
    /**
     * Для различных проверок
     */
    lastInformedCount?: number;
};