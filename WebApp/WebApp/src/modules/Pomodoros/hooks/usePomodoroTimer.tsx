import { useState } from "react"
import { Pomodoro } from "../model/pomodoro";
import { useDuration } from "./useDuration";

export enum TimerMode {
    Work = 'Work',
    Rest = 'Rest'
}

const { Work, Rest } = TimerMode;

export function usePomodoroTimer(props: Pomodoro) {

    const workTimer = useDuration({ duration: props.workDuration, onFinishedCallback });

    const restTimer = useDuration({ duration: props.restDuration, onFinishedCallback });

    const [ mode, setMode ] = useState(Work);

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

    }

    function onReset() {
        if(mode === Work){
            workTimer.reset();
        }
        else{
            restTimer.reset();
        }
    }

    function onToggle() {
        if(mode === Work){
            workTimer.toggle();
        }
        else{
            restTimer.toggle();
        }
    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay: workTimer.isOnPlay || restTimer.isOnPlay,
        isActive: workTimer.isActive || restTimer.isActive,
        duration: mode === Work ? workTimer.duration : restTimer.duration,
        mode: mode,
    }
}
