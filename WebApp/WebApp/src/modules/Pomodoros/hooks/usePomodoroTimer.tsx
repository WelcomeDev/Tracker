import { useEffect, useState } from "react"
import { toSeconds } from "../../../lib/time";
import { DurationDto } from "../model/duration";

export interface UsePomodoroTimerProps {
    duration: DurationDto;
}

export function usePomodoroTimer(props: UsePomodoroTimerProps) {

    const [ isOnPlay, setOnPlay ] = useState<boolean>(false)
    const [ isActive, setIsActive ] = useState<boolean>(false)

    const [ hours, setHours ] = useState(props.duration.hours);
    const [ minutes, setMinutes ] = useState(props.duration.minutes);
    const [ seconds, setSeconds ] = useState(0);
    const [ percent, setPercent ] = useState(100);

    function decreaseMinutes() {
        if (hours + minutes === 0)
            return;

        setSeconds(59);

        if (minutes === 0) {
            setHours(hours - 1);
            setMinutes(59);
            return;
        }

        setMinutes(minutes - 1);
    }

    useEffect(() => {
        if (!isOnPlay)
            return;

        //секунда не нулевая
        if (seconds !== 0) {
            setTimeout(() => {
                setSeconds(seconds - 1);
            }, 1000);
            return;
        }

        decreaseMinutes();
    }, [ seconds, isOnPlay ])

    useEffect(() => {
        const { minutes: totalM, hours: totalH } = props.duration;
        console.log(`${hours}:${minutes}:${seconds}`);
        setPercent(toSeconds(seconds, minutes, hours) / toSeconds(0, totalM, totalH))
    }, [ seconds, minutes, hours ])

    // useEffect(() => {
    //     //todo: sync
    // }, [ minutes ])

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

        //todo: fix onReset onPlay
        setHours(props.duration.hours);
        setMinutes(props.duration.minutes);
        setSeconds(0);
    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay, isActive,
        duration: { hours, minutes, seconds }, percent,
    }
}
