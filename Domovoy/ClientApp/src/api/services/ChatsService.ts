/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { Chat } from '../models/Chat';
import type { Message } from '../models/Message';

import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class ChatsService {

    /**
     * @returns Chat Success
     * @throws ApiError
     */
    public static getApiChats(): CancelablePromise<Array<Chat>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/chats',
        });
    }

    /**
     * @param requestBody 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiChatsAdd(
requestBody?: Array<number>,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/chats/add',
            body: requestBody,
            mediaType: 'application/json-patch+json',
        });
    }

    /**
     * @param chatId 
     * @returns Message Success
     * @throws ApiError
     */
    public static getApiChats1(
chatId: number,
): CancelablePromise<Array<Message>> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/api/chats/{chatId}',
            path: {
                'chatId': chatId,
            },
        });
    }

    /**
     * @param chatId 
     * @param text 
     * @returns any Success
     * @throws ApiError
     */
    public static postApiChatsSend(
chatId: number,
text?: string,
): CancelablePromise<any> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/api/chats/{chatId}/send',
            path: {
                'chatId': chatId,
            },
            query: {
                'text': text,
            },
        });
    }

}