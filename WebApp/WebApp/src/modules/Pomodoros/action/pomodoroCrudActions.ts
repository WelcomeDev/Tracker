import { getClient } from "../../Auth/actions/TokenClient";
import { Pomodoro } from "../model/pomodoro";
import { globalConfig } from "../../../config/globalConfig";
import axios from "axios";
import { CreatePomodoroParams } from '../interfaces/createPomodoroParams';
import { UpdatePomodoroParams } from '../interfaces/updatePomodoroParams';

const client = getClient();
const SERVICE_URL = `${globalConfig.baseURL}/pomodoro`

export function getAll(): Promise<Pomodoro[]> {
    return axios.get<Pomodoro[]>(SERVICE_URL, {
    })
        .then(x => {
            console.log(x);
            return x.data
            // x.data.forEach(x => console.log(x));
        });
}

export function get(id: string): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}`;
    return client.get<Pomodoro>(currentUrl)
        .then(x => x.data);
}

export function create(pomodoroData: CreatePomodoroParams): Promise<Pomodoro> {
    const createUrl = `${SERVICE_URL}/create`;
    return client.post<Pomodoro>(createUrl, pomodoroData)
        .then(x => x.data);
}


export function update(id: string, pomodoroData: UpdatePomodoroParams): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}/update`;
    return client.post<Pomodoro>(currentUrl, pomodoroData)
        .then(x => x.data);
}

//todo: check status code
export function remove(id: string) {
    const currentUrl = `${SERVICE_URL}/${id}/delete`;
    client.post<Pomodoro>(currentUrl)
        .then(x => console.log(x.status));
}
