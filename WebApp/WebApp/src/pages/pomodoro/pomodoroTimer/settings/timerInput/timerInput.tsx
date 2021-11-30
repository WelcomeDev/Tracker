import { Arrow, ArrowDirection } from '../../../../../components/input/arrow';
import './timerInput.scss';
import { useTimerInput } from '../../../../../modules/Pomodoros/hooks/useTimerInput';
import { Controller, UseFormRegisterReturn } from 'react-hook-form';
import NumberFormat from 'react-number-format';
import { doubleDigitTime } from '../../../../../lib/time';

const { TOP, BOTTOM } = ArrowDirection;

export interface TimerInputProps {
    register: UseFormRegisterReturn;

}

export function TimerInput({ register }: TimerInputProps) {
    const arrowStyle = {
        thickness: 3,
        cornerRadius: 10,
    };

    const {
              increase, decrease,
              control,
              name: registerName,
          } = useTimerInput(register);

    return (
        <section className={'timer-input'}>
            <Arrow
                onClick={increase}
                direction={TOP}
                {...arrowStyle}
                className={'timer-input__arrow-top'}
            />
            <Controller
                render={({ field: { onChange, onBlur, name, value } }) => (
                    <NumberFormat
                        format={(val) => doubleDigitTime(Number(val))}
                        displayType={'input'}
                        className={'timer-input__time'}
                        onBlur={onBlur}
                        value={value}
                        onChange={onChange}
                        name={name}
                    />
                )}
                name={registerName}
                control={control}
            />
            <Arrow
                onClick={decrease}
                direction={BOTTOM}
                {...arrowStyle}
                className={'timer-input__arrow-bottom'}
            />
        </section>
    );
}
