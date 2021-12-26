import { AuthParams } from '../interfaces/authParams';
import axios from 'axios';
import { globalConfig } from '../../../config/globalConfig';
import { Token } from '../model/token';
import { TokenStorage } from './TokenStorage';

const AUTH_URL = `${globalConfig.baseURL}/auth`;

export function login(params: AuthParams) {
    return axios
        .post<Token>(`${AUTH_URL}/login`, params)
        .then(resp => {
            TokenStorage.saveToken(resp.data);
            return resp.data;
        });
}
