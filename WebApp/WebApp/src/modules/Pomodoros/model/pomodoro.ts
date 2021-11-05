import * as t from "io-ts";
import { UserType } from "./user";
import { PomodoroEssentialsType } from "./pomodoroEssentials";
import { DurationDto } from "./duration";

export const PomodoroType = t.intersection([
    t.interface({
        user: UserType,
        id: t.string,
    }),
    PomodoroEssentialsType,
])

export interface PomodoroDto extends t.TypeOf<typeof PomodoroType> {
}

export class Pomodoro {
    private id: string;
    private title: string;
    private restDuration: DurationDto;
    private workDuration: DurationDto;

    constructor(pomodoro: PomodoroDto) {
        this.id = pomodoro.id;
        this.title = pomodoro.title;
        this.restDuration = pomodoro.restDuration;
        this.workDuration = pomodoro.workDuration;
    }
}

