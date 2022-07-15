/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ActiveSession } from './ActiveSession';
import type { Informer } from './Informer';

export type EventInformer = {
    id?: number;
    informer?: Informer;
    informertId?: number;
    /**
     * Активен прямо сейчас
     */
    isNowActive?: boolean;
    activeSessions?: Array<ActiveSession> | null;
    time?: string | null;
};