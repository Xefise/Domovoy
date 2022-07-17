/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentViewModel } from './ApartmentViewModel';
import type { ApplicationUserViewModel } from './ApplicationUserViewModel';
import type { InformerService } from './InformerService';

export type InformerServiceServiceEntryDTO = {
    id?: number;
    service?: InformerService;
    data?: string | null;
    completed?: boolean;
    user?: ApplicationUserViewModel;
    apartment?: ApartmentViewModel;
};