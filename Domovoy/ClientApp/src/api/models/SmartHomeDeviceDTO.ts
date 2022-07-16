/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { ISmartHomeDeviceAction } from './ISmartHomeDeviceAction';
import type { SmartHomeDeviceType } from './SmartHomeDeviceType';

export type SmartHomeDeviceDTO = {
    id?: number;
    smartHomeDeviceType?: SmartHomeDeviceType;
    actions?: Array<ISmartHomeDeviceAction> | null;
    apartmentId?: number;
};