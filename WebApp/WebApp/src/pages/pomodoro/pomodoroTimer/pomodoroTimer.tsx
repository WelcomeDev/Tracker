import './pomodoroItem.scss';
import { usePomodoroTimer } from '../../../modules/Pomodoros/hooks/usePomodoroTimer';
import classNames from 'classnames';
import { CSSProperties, useEffect, useRef, useState } from 'react';
import { TimerDisplay } from './display/timerDisplay/timerDisplay';
import { Modal } from '../../../components/modal/modal';
import { SettingsDisplay } from './settings/settingsDisplay/settingsDisplay';
import { observer } from 'mobx-react';
import { Pomodoro } from '../../../modules/Pomodoros/model/pomodoro';

export const PomodoroTimer = observer((pomodoro: Pomodoro) => {

    const pomodoroTimer = usePomodoroTimer(pomodoro);

    const {
              isOnSettings, setOnSettings,
          } = pomodoroTimer;

    const pomodoroRef = useRef<HTMLElement>(null);

    const [positionStyle, setPositionStyle] = useState<CSSProperties>();

    useEffect(() => {
        const centerX = pomodoroRef.current?.offsetLeft as number;
        const centerY = pomodoroRef.current?.offsetTop as number;

        const left = centerX - 150;
        const top  = centerY - 175;

        setPositionStyle({
            left: `${left}px`,
            top: `${top}px`,
        });
    }, [pomodoroRef]);

    return (
        <>
            <section className={'pomodoro'}
                     ref={pomodoroRef}>
                {
                    !isOnSettings &&
                    <TimerDisplay title={pomodoro.title}
                                  {...pomodoroTimer}/>
                }
            </section>
            <Modal
                onClose={() => setOnSettings(false)}
                menuClassName={classNames('settings', isOnSettings ? 'on-display' : '')}
                contentClassName={classNames('settings__content', isOnSettings ? 'on-display' : '')}
                contentStyle={!isOnSettings ? { ...positionStyle } : {}}>
                <SettingsDisplay
                    pomodoro={pomodoro}
                    onClose={() => setOnSettings(false)}
                />
            </Modal>
        </>
    );
});
