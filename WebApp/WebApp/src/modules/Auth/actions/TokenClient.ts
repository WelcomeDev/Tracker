import axios, { AxiosInstance } from 'axios';
import { globalConfig } from '../../../config/globalConfig';
import { TokenStorage } from './TokenStorage';

export class TokenClient {
    private client: AxiosInstance;

    constructor() {
        this.client = axios.create(({ baseURL: globalConfig.baseURL }));
        this.client.interceptors.request.use((config) => {
            const token = TokenStorage.getToken();
            config.headers = {
                'Authorization': `Bearer ${JSON.stringify(token)}`,
                'ContentType': 'application/json',
            };

            return config;
        });
    }

    private static tokenClient: TokenClient = new TokenClient();

    public static getInstance() {
        return this.tokenClient.client;
    }
}

