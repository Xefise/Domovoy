/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { SmartHomeDevice } from './SmartHomeDevice';

export type SmartHomeDeviceActionLogEntry = {
    id?: number;
    perfomed?: boolean;
    dateTime?: string;
    actionId?: string | null;
    smartHomeDevice?: SmartHomeDevice;
};