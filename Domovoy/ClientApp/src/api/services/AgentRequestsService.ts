/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApartmentRequestDTO } from '../models/ApartmentRequestDTO';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class AgentRequestsService {

    /**
     * @returns ApartmentRequestDTO Success
     * @throws ApiError
     */
    public static getApiAgentrequests(): CancelablePromise<Array<ApartmentRequestDTO>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/agentrequests',
        });
    }

    /**
     * @param requestId 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiAgentrequestsAccept(
requestId: number,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/agentrequests/accept/{requestId}',
            path: {
                'requestId': requestId,
            },
        });
    }

    /**
     * @param requestId 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiAgentrequestsDeny(
requestId: number,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/agentrequests/deny/{requestId}',
            path: {
                'requestId': requestId,
            },
        });
    }

}