/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ApartmentServiceServiceEntryDTO } from './ApartmentServiceServiceEntryDTO';
import type { InformerServiceServiceEntryDTO } from './InformerServiceServiceEntryDTO';
import type { UserServiceServiceEntryDTO } from './UserServiceServiceEntryDTO';

export type ServiceEntriesCollection = {
    userServicesEntries?: Array<UserServiceServiceEntryDTO> | null;
    apartmentServicesEntries?: Array<ApartmentServiceServiceEntryDTO> | null;
    informerServicesEntries?: Array<InformerServiceServiceEntryDTO> | null;
};