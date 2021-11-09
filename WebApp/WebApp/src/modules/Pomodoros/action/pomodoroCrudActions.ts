import { getClient } from "../../Main/actions/TokenClient";
import { Pomodoro } from "../model/pomodoro";
import { PomodoroEssentialsDto } from "../model/pomodoroEssentials";

const client = getClient();
const SERVICE_URL = 'pomodoro'

export function getAll() {
    client.get<Pomodoro[]>(SERVICE_URL)
          .then(x => x.data.forEach(x => console.log(x)));
}

export function get(id: string) {
    const currentUrl = `${SERVICE_URL}/${id}`;
    client.get<Pomodoro>(currentUrl)
          .then(x => console.log(x.data));
}

const CREATE_URL = `${SERVICE_URL}/create`;

export function create(pomodoroData: PomodoroEssentialsDto) {
    client.post<Pomodoro>(CREATE_URL, pomodoroData)
          .then(x => console.log(x.data))
}

//todo: complete crud
//todo: return data from methods
