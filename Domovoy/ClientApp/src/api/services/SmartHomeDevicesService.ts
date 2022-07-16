/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { SmartHomeDeviceActionLogEntryDTO } from '../models/SmartHomeDeviceActionLogEntryDTO';
import type { SmartHomeDeviceDTO } from '../models/SmartHomeDeviceDTO';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class SmartHomeDevicesService {

    /**
     * @param apartmentId 
     * @returns SmartHomeDeviceDTO Success
     * @throws ApiError
     */
    public static getApiSmarthomedevicesApartment(
apartmentId: number,
): CancelablePromise<Array<SmartHomeDeviceDTO>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/smarthomedevices/apartment/{apartmentId}',
            path: {
                'apartmentId': apartmentId,
            },
        });
    }

    /**
     * @param deviceId 
     * @param actionId 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiSmarthomedevicesUse(
deviceId: number,
actionId?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/smarthomedevices/use/{deviceId}',
            path: {
                'deviceId': deviceId,
            },
            query: {
                'actionId': actionId,
            },
        });
    }

    /**
     * @param deviceId 
     * @returns SmartHomeDeviceActionLogEntryDTO Success
     * @throws ApiError
     */
    public static getApiSmarthomedevicesUpdates(
deviceId: number,
): CancelablePromise<Array<SmartHomeDeviceActionLogEntryDTO>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/smarthomedevices/updates/{deviceId}',
            path: {
                'deviceId': deviceId,
            },
        });
    }

}