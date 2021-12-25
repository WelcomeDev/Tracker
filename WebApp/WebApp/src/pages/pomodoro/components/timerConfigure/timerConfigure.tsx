import './timerConfigure.scss';
import classNames from 'classnames';
import { TimerInput } from '../timerInput/timerInput';
import { UseFormRegisterReturn } from 'react-hook-form';
import { observer } from 'mobx-react';

export interface TimerConfigureProps {
    title: string;
    className?: string;
    hoursRegister: UseFormRegisterReturn;
    minutesRegister: UseFormRegisterReturn;
}

export const TimerConfigure = observer((props: TimerConfigureProps) => {

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
});
