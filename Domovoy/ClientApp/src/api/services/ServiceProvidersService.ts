/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ServiceEntriesCollection } from '../models/ServiceEntriesCollection';
import type { ServiceType } from '../models/ServiceType';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ServiceProvidersService {

    /**
     * @returns ServiceEntriesCollection Success
     * @throws ApiError
     */
    public static getApiServiceprovidersEntries(): CancelablePromise<ServiceEntriesCollection> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/serviceproviders/entries',
        });
    }

    /**
     * @param entryId 
     * @param type 
     * @returns any Success
     * @throws ApiError
     */
    public static getApiServiceprovidersComplete(
entryId: number,
type?: ServiceType,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/serviceproviders/complete/{entryId}',
            path: {
                'entryId': entryId,
            },
            query: {
                'type': type,
            },
        });
    }

}