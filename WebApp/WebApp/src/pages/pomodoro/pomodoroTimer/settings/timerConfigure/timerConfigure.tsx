import './timerConfigure.scss';
import classNames from 'classnames';
import { TimerInput } from '../timerInput/timerInput';
import { UseFormRegisterReturn } from 'react-hook-form';

export interface TimerConfigureProps {
    title: string;
    className?: string;
    hoursRegister: UseFormRegisterReturn;
    minutesRegister: UseFormRegisterReturn;
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
                    register={hoursRegister}/>
                <p>:</p>
                <TimerInput
                    register={minutesRegister}/>
            </section>
        </section>
    );
}
