/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApartmentViewModel } from '../models/ApartmentViewModel';
import type { SerachFilters } from '../models/SerachFilters';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantSearchService {

    /**
     * @param requestBody 
     * @returns ApartmentViewModel Success
     * @throws ApiError
     */
    public static postApiTenantsearch(
requestBody?: SerachFilters,
): CancelablePromise<Array<ApartmentViewModel>> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantsearch',
            body: requestBody,
            mediaType: 'application/json-patch+json',
        });
    }

}