/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApartmentPutTenant } from '../models/ApartmentPutTenant';
import type { ApartmentViewModel } from '../models/ApartmentViewModel';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantAppartamentsService {

    /**
     * @returns ApartmentViewModel Success
     * @throws ApiError
     */
    public static getApiTenantappartaments(): CancelablePromise<Array<ApartmentViewModel>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/tenantappartaments',
        });
    }

    /**
     * @param id 
     * @param requestBody 
     * @returns ApartmentViewModel Success
     * @throws ApiError
     */
    public static putApiTenantappartaments(
id: number,
requestBody?: ApartmentPutTenant,
): CancelablePromise<ApartmentViewModel> {
        return __request(OpenAPI, {
            method: 'PUT',
            url: '/api/tenantappartaments/{id}',
            path: {
                'id': id,
            },
            body: requestBody,
            mediaType: 'application/json-patch+json',
        });
    }

    /**
     * @param code 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantappartamentsJoin(
code?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantappartaments/join',
            query: {
                'code': code,
            },
        });
    }

}