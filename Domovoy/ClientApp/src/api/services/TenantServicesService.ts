/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ServicesCollection } from '../models/ServicesCollection';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantServicesService {

    /**
     * @param apartmentId 
     * @returns ServicesCollection Success
     * @throws ApiError
     */
    public static getApiTenantservices(
apartmentId: number,
): CancelablePromise<ServicesCollection> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/tenantservices/{apartmentId}',
            path: {
                'apartmentId': apartmentId,
            },
        });
    }

    /**
     * @param apartmentId 
     * @param serviceId 
     * @param data 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantservicesRequestApartment(
apartmentId: number,
serviceId: number,
data?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantservices/request/apartment/{apartmentId}/{serviceId}',
            path: {
                'apartmentId': apartmentId,
                'serviceId': serviceId,
            },
            query: {
                'data': data,
            },
        });
    }

    /**
     * @param apartmentId 
     * @param serviceId 
     * @param data 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantservicesRequestInformer(
apartmentId: number,
serviceId: number,
data?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantservices/request/informer/{apartmentId}/{serviceId}',
            path: {
                'apartmentId': apartmentId,
                'serviceId': serviceId,
            },
            query: {
                'data': data,
            },
        });
    }

    /**
     * @param serviceId 
     * @param data 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantservicesRequestUser(
serviceId: number,
data?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantservices/request/user/{serviceId}',
            path: {
                'serviceId': serviceId,
            },
            query: {
                'data': data,
            },
        });
    }

}