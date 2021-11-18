import './timerConfigure.scss'
import classNames from "classnames";
import { TimerInput } from "../timerInput/timerInput";
import { Action } from "../../../../../../components/interfaces/actionTyped";

export interface TimerConfigureProps {
    title: string;
    className?: string;
    hoursRegister: ManagedDurationInputProps;
    minutesRegister: ManagedDurationInputProps;
}

export interface ManagedDurationInputProps {
    maxValue: number;
    initialValue: number;
    setTime: Action<number>;
}

export function TimerConfigure(props: TimerConfigureProps) {

    const {
        hoursRegister, minutesRegister,
        title,
        className,
    } = props;

    return (
        <section className={classNames(className, 'timer-configure')}>
            <p>
                {title}
            </p>
            <section className={'timer-configure__input'}>
                <TimerInput
                    name={`${title}_hours`}
                    {...hoursRegister}/>
                <p>:</p>
                <TimerInput
                    name={`${title}_minutes`}
                    {...minutesRegister}/>
            </section>
        </section>
    )
}
