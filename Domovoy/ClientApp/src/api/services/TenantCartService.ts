/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApartmentViewModel } from '../models/ApartmentViewModel';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantCartService {

    /**
     * @returns ApartmentViewModel Success
     * @throws ApiError
     */
    public static getApiTenantcart(): CancelablePromise<Array<ApartmentViewModel>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/tenantcart',
        });
    }

    /**
     * @param apartmentId 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantcart(
apartmentId?: number,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantcart',
            query: {
                'apartmentId': apartmentId,
            },
        });
    }

    /**
     * @param apartmentId 
     * @returns any Success
     * @throws ApiError
     */
    public static deleteApiTenantcart(
apartmentId?: number,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'DELETE',
            url: '/api/tenantcart',
            query: {
                'apartmentId': apartmentId,
            },
        });
    }

}