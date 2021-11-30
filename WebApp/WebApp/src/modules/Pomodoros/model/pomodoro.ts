import * as t from "io-ts";
import { UserType } from "../../Main/model/user";
import { PomodoroEssentialsType } from "./pomodoroEssentials";
import { Duration } from './duration';

export const PomodoroType = t.intersection([
    t.interface({
        user: UserType,
        id: t.string,
    }),
    PomodoroEssentialsType,
])

export interface PomodoroDto extends t.TypeOf<typeof PomodoroType> {
}

export class Pomodoro{
    id: string;
    title: string;
    restDuration: Duration;
    workDuration: Duration;

    constructor(pomodoro: PomodoroDto) {
        this.id = pomodoro.id;
        this.title = pomodoro.title;
        this.restDuration = new Duration(pomodoro.restDuration);
        this.workDuration = new Duration(pomodoro.workDuration);
    }
}

