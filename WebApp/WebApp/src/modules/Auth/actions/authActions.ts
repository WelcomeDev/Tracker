import { AuthParams } from '../interfaces/authParams';
import axios from 'axios';
import { globalConfig } from '../../../config/globalConfig';

const AUTH_URL = `${globalConfig.baseURL}/auth`;

export function login(params: AuthParams) {
    return axios
        .get(AUTH_URL)
        .then(resp => {
            return resp.data;
        });
}

export function logout() {
// todo: logout
}