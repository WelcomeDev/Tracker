import { createContext } from "react";
import { Action } from "../../../../components/interfaces/actionTyped";
import { Pomodoro } from "../../model/pomodoro";

export interface PomodoroSettingsService {
    configure: Action<Pomodoro>;
}

export const pomodoroSettingsContext = createContext({} as PomodoroSettingsService);
