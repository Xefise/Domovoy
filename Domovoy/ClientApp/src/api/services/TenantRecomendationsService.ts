/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { ApartmentViewModel } from '../models/ApartmentViewModel';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TenantRecomendationsService {

    /**
     * @returns ApartmentViewModel Success
     * @throws ApiError
     */
    public static getApiTenantrecomendations(): CancelablePromise<Array<ApartmentViewModel>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/tenantrecomendations',
        });
    }

}