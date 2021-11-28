import { TimerInputProps } from "../../../pages/pomodoro/pomodoroTimer/settings/timerInput/timerInput";
import { useEffect, useRef, useState } from "react";
import { doubleDigitTime } from "../../../lib/time";

export function useTimerInput(props: TimerInputProps) {

    const [ time, setTime ] = useState(props.initialValue);
    const inputRef = useRef<HTMLInputElement>(null)
    const validity = `Value must be less than ${props.maxValue}`;

    useEffect(() => {
        props.setTime(time);
        const el = inputRef.current as HTMLInputElement;
        el.value = doubleDigitTime(time);
        el.setCustomValidity('');
    }, [ time ])

    function increase() {
        if (time < props.maxValue) {
            setTime(time + 1);
        } else {
            setTime(0)
        }
    }

    function decrease() {
        if (time > 0 && time <= props.maxValue) {
            setTime(time - 1);
        } else {
            setTime(props.maxValue);
        }
    }

    function onSet(value: number) {
        const el = inputRef.current as HTMLInputElement;
        if (value > props.maxValue || value < 0) {
            el.setCustomValidity(validity);
        } else {
            setTime(value);
        }
    }

    return {
        increase, decrease,
        time, onSet,
        inputRef,
    }
}
