import { makeAutoObservable } from 'mobx';
import { Pomodoro } from '../modules/Pomodoros/model/pomodoro';
import { getAll, remove, update } from '../modules/Pomodoros/action/pomodoroCrudActions';
import { UpdatePomodoroParams } from '../modules/Pomodoros/interfaces/updatePomodoroParams';

export class PomodoroStore {
    pomodoroList: Pomodoro[] = [];
    isLoading: boolean       = false;

    constructor() {
        makeAutoObservable(this);
    }

    loadPomodoroList = async () => {
        this.isLoading    = true;
        this.pomodoroList = await getAll();
        this.isLoading    = false;
    };

    removePomodoro = async (pomodoro: Pomodoro) => {
        this.isLoading = true;
        await remove(pomodoro.id);
        const itemIndex = this.pomodoroList.indexOf(pomodoro);
        this.pomodoroList.splice(itemIndex, 1);
        this.isLoading = false;
    };

    updatePomodoro = async (pomodoro: Pomodoro, params: UpdatePomodoroParams) => {
        const value           = await update(pomodoro.id, params);
        pomodoro.title        = value.title;
        pomodoro.restDuration = value.restDuration;
        pomodoro.workDuration = value.workDuration;
    };
}