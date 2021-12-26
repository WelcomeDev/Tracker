import axios, { AxiosInstance } from 'axios';
import { globalConfig } from '../../../config/globalConfig';
import { TokenStorage } from './TokenStorage';

export class TokenClient {
    private client: AxiosInstance;

    constructor() {
        this.client = axios.create(({ baseURL: globalConfig.baseURL }));
    }

    private static tokenClient: TokenClient = new TokenClient();

    public static getInstance() {
        this.tokenClient.client.interceptors.request.use((config) => {
            const token = TokenStorage.getToken();
            config.headers = {
                'Authorization': `Bearer ${token?.accessToken ?? ''}`,
                'ContentType': 'application/json',
            };
            console.log(config);
            return config;
        });

        return this.tokenClient.client;
    }
}

