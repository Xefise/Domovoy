/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { Apartment } from './Apartment';
import type { SmartHomeDeviceActionLogEntry } from './SmartHomeDeviceActionLogEntry';
import type { SmartHomeDeviceType } from './SmartHomeDeviceType';

export type SmartHomeDevice = {
    id?: number;
    smartHomeDeviceType?: SmartHomeDeviceType;
    apartment?: Apartment;
    apartmentId?: number;
    actionLogEntries?: Array<SmartHomeDeviceActionLogEntry> | null;
};