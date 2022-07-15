/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { EventInformer } from './EventInformer';
import type { InformMeter } from './InformMeter';

export type Informer = {
    id?: number;
    name?: string | null;
    lastInform?: string;
    isActive?: boolean;
    apartment?: Apartment;
    apartmentId?: number;
    informMeterId?: number | null;
    informMeter?: InformMeter;
    eventInformerId?: number | null;
    eventInformer?: EventInformer;
};