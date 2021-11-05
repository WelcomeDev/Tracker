import { useState } from "react"
import { PomodoroDto } from "../model/pomodoro";

export interface UsePomodoroTimerProps {
    pomodoro: PomodoroDto;
}

export function usePomodoroTimer(props: UsePomodoroTimerProps) {

    const [ isOnPlay, setOnPlay ] = useState<boolean>(false)
    const [ isActive, setIsActive ] = useState<boolean>(false)

    const [ hours, setHours ] = useState(props.pomodoro.workDuration.hours);
    const [ minutes, setMinutes ] = useState(props.pomodoro.workDuration.minutes);
    const [ seconds, setSeconds ] = useState(0);
    const [ percent, setPercent ] = useState(100);

    function onSettings() {

    }

    function onToggle() {
        if (!isActive)
            setIsActive(true)

        setOnPlay(!isOnPlay);
    }

    function onReset() {
        setIsActive(false);
        setOnPlay(false);
    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay, isActive,
        duration: { hours, minutes, seconds }, percent,
    }
}
