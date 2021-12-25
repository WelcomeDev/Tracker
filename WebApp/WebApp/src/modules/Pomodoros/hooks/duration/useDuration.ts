import { DurationDto } from "../../model/duration";
import { useEffect, useState } from "react";
import { Action } from "../../../../components/interfaces/action";
import { cancellablePromise } from "../../../../lib/cancellablePromise";
import { toSeconds } from "../../../../lib/time";

export interface UseDurationProps {
    duration: DurationDto;
    onFinishedCallback?: Action;
}

export interface DurationDisplayData {
    hours: number;
    minutes: number;
    seconds: number;
    percent: number;
}

export function useDuration({ duration, onFinishedCallback }: UseDurationProps) {

    const [ isOnPlay, setOnPlay ] = useState<boolean>(false)
    const [ isActive, setIsActive ] = useState<boolean>(false)

    const [ hours, setHours ] = useState(duration.hours);
    const [ minutes, setMinutes ] = useState(duration.minutes);
    const [ seconds, setSeconds ] = useState(0);
    const [ percent, setPercent ] = useState(100);
    const [ refreshSeconds, setRefreshSeconds ] = useState<{ promise: Promise<unknown>, cancel: Action }>();

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
            const onRefreshSeconds = cancellablePromise<number>(new Promise((resolve) =>
                setTimeout(() => {
                    resolve(seconds - 1);
                }, 1000),
            ))
            onRefreshSeconds.promise.then((seconds) => {
                setSeconds(seconds);
            });
            setRefreshSeconds(onRefreshSeconds)
            return;
        }

        decreaseMinutes();
    }, [ seconds, isOnPlay ])

    useEffect(() => {
        if (!isActive) {
            setSeconds(0);
            setMinutes(duration.minutes);
            setHours(duration.hours);
            setPercent(100);
            return;
        }

        const { minutes: totalM, hours: totalH } = duration;
        const perCent = Math.round(toSeconds(seconds, minutes, hours) / toSeconds(0, totalM, totalH) * 100);
        setPercent(perCent)

        if (perCent === 0 && onFinishedCallback) {
            setIsActive(false);
            setOnPlay(false);
            onFinishedCallback();
        }
    }, [ seconds, minutes, hours, isActive ])

    function reset() {
        setIsActive(false);
        setOnPlay(false);
    }

    function toggle() {
        if (!isActive) {
            setIsActive(true)
        }

        if (isOnPlay) {
            refreshSeconds?.cancel();
        }

        setOnPlay(!isOnPlay);
    }

    return {
        duration: { hours, minutes, seconds, percent },
        reset, toggle,
        isOnPlay, isActive,
    }
}
