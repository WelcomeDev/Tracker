import { useState } from "react"
import { Pomodoro } from "../model/pomodoro";
import { DurationDisplayData, useDuration } from "./duration/useDuration";
import { Action as ActionT } from "../../../components/interfaces/actionTyped";
import { Action } from "../../../components/interfaces/action";

export enum TimerMode {
    Work = 'work',
    Rest = 'rest'
}

const { Work, Rest } = TimerMode;

export interface UsePomodoroTimerService {
    onReset: Action;
    onToggle: Action;
    onSettings: Action;
    isOnPlay: boolean;
    isActive: boolean;
    duration: DurationDisplayData;
    mode: TimerMode;
    isOnSettings: boolean;
    setOnSettings: ActionT<boolean>;
}

export function usePomodoroTimer(pomodoro : Pomodoro) {

    const workTimer = useDuration({ duration: pomodoro.workDuration, onFinishedCallback });

    const restTimer = useDuration({ duration: pomodoro.restDuration, onFinishedCallback });

    const [ mode, setMode ] = useState(Work);
    const [ isOnSettings, setOnSettings ] = useState<boolean>(false)

    function onFinishedCallback() {
        if (mode === Work) {
            setMode(Rest);
            restTimer.toggle();
            workTimer.reset();
            console.log(`Work is over`);
        } else {
            setMode(Work);
            restTimer.reset();
            console.log(`Rest is over`);
        }
    }

    function onSettings() {
        setOnSettings(true);
    }

    function onReset() {
        if (mode === Work) {
            workTimer.reset();
        } else {
            restTimer.reset();
        }
    }

    function onToggle() {
        if (mode === Work) {
            workTimer.toggle();
        } else {
            restTimer.toggle();
        }
    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay: workTimer.isOnPlay || restTimer.isOnPlay,
        isActive: workTimer.isActive || restTimer.isActive,
        duration: mode === Work ? workTimer.duration : restTimer.duration,
        mode: mode,
        isOnSettings, setOnSettings,
    }
}
