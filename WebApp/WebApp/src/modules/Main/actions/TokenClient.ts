import axios, { AxiosInstance } from 'axios'
import { globalConfig } from "../../../config/globalConfig";

const client = axios.create(({ baseURL: globalConfig.baseURL }));

client.interceptors.request.use(config => {
    //todo: complete auth actions
});

// client.interceptors.response.use(
//     response => Promise.resolve(response),
//     error => onTryRefresh(error));

function onTryRefresh(error: any): Promise<any> {
    if (!error.response)
        return Promise.reject(error);

    const errorObj = error.response.data;
    //todo: complete refresh actions
    return Promise.reject(errorObj);
}

export function getClient(): AxiosInstance {
    return client;
}

