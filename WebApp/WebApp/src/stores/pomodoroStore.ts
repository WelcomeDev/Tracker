import { action, makeAutoObservable, observable } from 'mobx';
import { Pomodoro } from '../modules/Pomodoros/model/pomodoro';
import { create, getAll, remove, update } from '../modules/Pomodoros/action/pomodoroCrudActions';
import { UpdatePomodoroParams } from '../modules/Pomodoros/interfaces/updatePomodoroParams';
import { CreatePomodoroParams } from '../modules/Pomodoros/interfaces/createPomodoroParams';

export class PomodoroStore {
    @observable pomodoroList: Pomodoro[] = [];
    @observable isLoading: boolean       = false;

    constructor() {
        makeAutoObservable(this);
    }

    @action
    loadPomodoroList = async () => {
        this.isLoading = true;

        this.pomodoroList = await getAll();

        this.isLoading = false;
    };

    @action
    removePomodoro = async (pomodoro: Pomodoro) => {
        this.isLoading = true;

        await remove(pomodoro.id);
        const itemIndex = this.pomodoroList.indexOf(pomodoro);
        this.pomodoroList.splice(itemIndex, 1);

        this.isLoading = false;
    };

    @action
    updatePomodoro = async (pomodoro: Pomodoro, params: UpdatePomodoroParams) => {
        this.isLoading = true;

        const value = await update(pomodoro.id, params);
        pomodoro.update(value);

        this.isLoading = false;
    };

    @action
    createPomodoro = async (params: CreatePomodoroParams) => {
        this.isLoading = true;

        const value = await create(params);
        this.pomodoroList.push(value);

        this.isLoading = false;
    };
}