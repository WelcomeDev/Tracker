import './timerConfigure.scss'
import classNames from "classnames";
import { TimerInput } from "../timerInput/timerInput";
import { useState } from "react";

export interface TimerConfigureProps {
    title: string;
    className?: string;
}

export function TimerConfigure(props: TimerConfigureProps) {

    const [ hours, setHours ] = useState(0);
    const [ minutes, setMinutes ] = useState(0);

    return (
        <section className={classNames(props.className, 'timer-configure')}>
            <p>
                {props.title}
            </p>
            <section className={'timer-configure__input'}>
                <TimerInput
                    initialValue={hours}
                    setTime={setHours}
                    maxValue={23}/>
                <p>:</p>
                <TimerInput
                    initialValue={minutes}
                    setTime={setMinutes}
                    maxValue={59}
                />
            </section>
        </section>
    )
}
