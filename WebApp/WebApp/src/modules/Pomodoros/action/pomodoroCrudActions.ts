import { TokenClient } from '../../Auth/actions/TokenClient';
import { Pomodoro, PomodoroDto } from '../model/pomodoro';
import { globalConfig } from '../../../config/globalConfig';
import { CreatePomodoroParams } from '../interfaces/createPomodoroParams';
import { UpdatePomodoroParams } from '../interfaces/updatePomodoroParams';
import { ApiList } from '../../../components/interfaces/api/apiList';

const SERVICE_URL = `${globalConfig.baseURL}/pomodoro`;

export function getAll(): Promise<Pomodoro[]> {
    return TokenClient.getInstance()
        .get<ApiList<PomodoroDto>>(SERVICE_URL, {})
        .then(resp => {
            return resp.data.items.map(item => {
                return new Pomodoro(item);
            });
        });
}

export function get(id: string): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}`;
    return TokenClient.getInstance()
        .get<Pomodoro>(currentUrl)
        .then(x => x.data);
}

export function create(pomodoroData: CreatePomodoroParams): Promise<Pomodoro> {
    const createUrl = `${SERVICE_URL}/create`;
    return TokenClient.getInstance()
        .post<Pomodoro>(createUrl, pomodoroData)
        .then(x => x.data);
}


export function update(id: string, pomodoroData: UpdatePomodoroParams): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}/update`;
    return TokenClient.getInstance()
        .post<Pomodoro>(currentUrl, pomodoroData)
        .then(x => x.data);
}

export function remove(id: string) {
    const currentUrl = `${SERVICE_URL}/${id}/delete`;
    return TokenClient.getInstance()
        .post(currentUrl);
}
