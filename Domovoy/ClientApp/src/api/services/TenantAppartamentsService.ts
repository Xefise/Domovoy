/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
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