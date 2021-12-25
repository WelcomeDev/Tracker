import * as t from 'io-ts';
import { UserType } from '../../Main/model/user';
import { PomodoroEssentialsType } from './pomodoroEssentials';
import { Duration } from './duration';
import { action, makeAutoObservable, observable } from 'mobx';

export const PomodoroType = t.intersection([
    t.interface({
        user: UserType,
        id: t.string,
    }),
    PomodoroEssentialsType,
]);

export interface PomodoroDto extends t.TypeOf<typeof PomodoroType> {
}

export class Pomodoro {
    id: string;
    @observable title: string;
    @observable restDuration: Duration;
    @observable workDuration: Duration;

    constructor(pomodoro: PomodoroDto) {
        this.id           = pomodoro.id;
        this.title        = pomodoro.title;
        this.restDuration = new Duration(pomodoro.restDuration);
        this.workDuration = new Duration(pomodoro.workDuration);

        makeAutoObservable(this);
    }

    @action
    update = (updated: Pomodoro) => {
        this.title        = updated.title;
        this.restDuration = updated.restDuration;
        this.workDuration = updated.workDuration;
    };
}

