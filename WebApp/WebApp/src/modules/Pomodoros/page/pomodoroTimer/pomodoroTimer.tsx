import './pomodoroItem.scss';
import { usePomodoroTimer } from '../../hooks/usePomodoroTimer';
import { Pomodoro } from "../../model/pomodoro";
import { Action } from "../../../../components/interfaces/actionTyped";
import classNames from "classnames";
import { CSSProperties, useEffect, useRef, useState } from "react";
import { TimerDisplay } from "./timerDisplay/timerDisplay";
import { Modal } from "../../../../components/modal/modal";
import { SettingsDisplay } from "./settingsDisplay/settingsDisplay";

export interface PomodoroTimerProps {
    pomodoro: Pomodoro;
    onConfigure: Action<Pomodoro>
}

export function PomodoroTimer(props: PomodoroTimerProps) {

    const pomodoroTimer = usePomodoroTimer({ ...props });

    const {
        isOnSettings, setOnSettings,
    } = pomodoroTimer;

    const pomodoroRef = useRef<HTMLElement>(null);

    const [ positionStyle, setPositionStyle ] = useState<CSSProperties>();

    useEffect(() => {
        const centerX = pomodoroRef.current?.offsetLeft as number;
        const centerY = pomodoroRef.current?.offsetTop as number;

        const left = centerX - 150;
        const top = centerY - 175;

        setPositionStyle({
            left: `${left}px`,
            top: `${top}px`,
        });
    }, [ pomodoroRef ])

    return (
        <>
            <section className={"pomodoro"}
                     ref={pomodoroRef}>
                {
                    !isOnSettings &&
                    <TimerDisplay title={props.pomodoro.title}
                                  {...pomodoroTimer}/>
                }
            </section>
            <Modal
                onClose={() => setOnSettings(false)}
                menuClassName={classNames('settings', isOnSettings ? 'on-display' : '')}
                contentClassName={classNames('settings__content', isOnSettings ? 'on-display' : '')}
                contentStyle={!isOnSettings ? { ...positionStyle } : {}}>
                <SettingsDisplay/>
            </Modal>
        </>
    )
}
