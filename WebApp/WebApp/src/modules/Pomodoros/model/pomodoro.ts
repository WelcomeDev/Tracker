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

export class Pomodoro{
    private readonly _id: string;
    private readonly _title: string;
    private readonly _restDuration: DurationDto;
    private readonly _workDuration: DurationDto;

    constructor(pomodoro: PomodoroDto) {
        this._id = pomodoro.id;
        this._title = pomodoro.title;
        this._restDuration = pomodoro.restDuration;
        this._workDuration = pomodoro.workDuration;
    }

    get id(): string {
        return this._id;
    }

    get title(): string {
        return this._title;
    }

    get restDuration(): DurationDto {
        return this._restDuration;
    }

    get workDuration(): DurationDto {
        return this._workDuration;
    }

}

