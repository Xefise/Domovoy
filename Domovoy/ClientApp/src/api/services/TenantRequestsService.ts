/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantRequestsService {

    /**
     * @param apartmentId 
     * @param additional 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiTenantrequests(
apartmentId: number,
additional?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/tenantrequests/{apartmentId}',
            path: {
                'apartmentId': apartmentId,
            },
            query: {
                'additional': additional,
            },
        });
    }

}