import { getClient } from "../../Main/actions/TokenClient";
import { Pomodoro } from "../model/pomodoro";
import { PomodoroEssentialsDto } from "../model/pomodoroEssentials";
import { globalConfig } from "../../../config/globalConfig";
import axios from "axios";

const client = getClient();
const SERVICE_URL = `${globalConfig.baseURL}/pomodoro`

export function getAll(): Promise<Pomodoro[]> {
    console.log('on get all')
    return axios.get<Pomodoro[]>(SERVICE_URL, {
                    headers: {
                        "access-control-allow-origin": 'https://localhost',
                    },
                })
                .then(x => {
                    console.log(x);
                    return x.data
                    // x.data.forEach(x => console.log(x));
                });
    // client.get<any>(SERVICE_URL)
    //       .then(x => {
    //           console.log(x);
    //           // x.data.forEach(x => console.log(x));
    //       })
    //       .catch(e => console.log(e));
}

export function get(id: string): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}`;
    return client.get<Pomodoro>(currentUrl)
                 .then(x => x.data);
}

export function create(pomodoroData: PomodoroEssentialsDto): Promise<Pomodoro> {
    const CREATE_URL = `${SERVICE_URL}/create`;
    return client.post<Pomodoro>(CREATE_URL, pomodoroData)
                 .then(x => x.data);
}


export function update(id: string, pomodoroData: PomodoroEssentialsDto): Promise<Pomodoro> {
    const currentUrl = `${SERVICE_URL}/${id}/update`;
    return client.post<Pomodoro>(currentUrl, pomodoroData)
                 .then(x => x.data);
}

//todo: check statu scode
export function remove(id: string) {
    const currentUrl = `${SERVICE_URL}/${id}/delete`;
    client.post<Pomodoro>(currentUrl)
          .then(x => console.log(x.status));
}
