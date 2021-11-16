import { Arrow, ArrowDirection } from "../../../../../components/input/arrow";
import './timerInput.scss';
import classNames from "classnames";
import { Action } from "../../../../../components/interfaces/actionTyped";
import { useTimerInput } from "../../../hooks/useTimerInput";

const { TOP, BOTTOM } = ArrowDirection;

export interface TimerInputProps {
    initialValue: number;
    setTime: Action<number>;
    maxValue: number;
}

export function TimerInput(props: TimerInputProps) {
    const arrowStyle = {
        thickness: 3,
        cornerRadius: 10,
    }

    const {
        increase, decrease,
        onSet,
        inputRef,
    } = useTimerInput(props)

    return (
        <section className={'timer-input'}>
            <Arrow
                onClick={increase}
                direction={TOP}
                {...arrowStyle}
                className={'timer-input__arrow-top'}
            />
            <input type="text"
                   maxLength={2}
                   pattern={'^[\\d]{1,2}$'}
                   ref={inputRef}
                   onBlur={(e) => {
                       const value = Number(e.target.value);

                       if (value) {
                           onSet(value)
                       }
                   }}
                   className={classNames('timer-input__time')}/>
            <Arrow
                onClick={decrease}
                direction={BOTTOM}
                {...arrowStyle}
                className={'timer-input__arrow-bottom'}
            />
        </section>
    )
}
