import { action, observable } from 'mobx';
import { Pomodoro } from '../modules/Pomodoros/model/pomodoro';
import { getAll } from '../modules/Pomodoros/action/pomodoroCrudActions';

export class PomodoroStore {
    @observable pomodoroList: Pomodoro[];

    constructor() {
        this.pomodoroList = [];
    }

    @action('update pomodoro list')
    loadPomodoroList() {
        return getAll()
            .then(res => this.pomodoroList = res);
    }
}