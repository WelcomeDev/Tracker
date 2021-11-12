import { FlexContainer } from 'components/alignment/flexConteiner';
import './pomodoroItem.scss';
import { Timer } from './timer/timer';
import { usePomodoroTimer } from '../../hooks/usePomodoroTimer';
import { ReactComponent as Options } from './assets/options.svg';
import { ReactComponent as Pause } from './assets/pause.svg';
import { ReactComponent as Play } from './assets/play.svg';
import { ReactComponent as Stop } from './assets/stop.svg';
import { Pomodoro } from "../../model/pomodoro";
import { Action } from "../../../../components/interfaces/actionTyped";
import classNames from "classnames";
import { CSSProperties, useEffect, useRef, useState } from "react";

export interface PomodoroTimerProps {
    pomodoro: Pomodoro;
    onConfigure: Action<Pomodoro>
}

export function PomodoroTimer(props: PomodoroTimerProps) {

    const { title } = props.pomodoro;

    const {
        onSettings, onReset, onToggle,
        isOnPlay, isActive,
        duration,
        mode,
        isOnSettings, setOnSettings,
    } = usePomodoroTimer({ ...props });

    const pomodoroRef = useRef<HTMLElement>(null);

    const [ positionStyle, setPositionStyle ] = useState<CSSProperties>()

    useEffect(()=>{
        console.log(`Is on settings ${isOnSettings}`)
    },[isOnSettings])

    useEffect(() => {
        setPositionStyle({
            //@ts-ignore
            left: pomodoroRef.current?.offsetLeft - 150,
            //@ts-ignore
            top: pomodoroRef.current?.offsetTop - 175,
        });
    }, [ pomodoroRef ])

    return (
        <>
            <section className={"pomodoro"}
                     ref={pomodoroRef}>
                {
                    !isOnSettings &&
                    <>
                        <p className="pomodoro__title">
                            <span>{title}</span>
                            <span style={{ opacity: 0.6 }}> {mode}</span>
                        </p>
                        <Timer
                            className="pomodoro__timer"
                            {...duration}/>
                        <FlexContainer
                            className="pomodoro__actions"
                            justifyContent="space-around"
                        >
                            {
                                isOnPlay ?
                                    <Pause
                                        title="Pause"
                                        onClick={onToggle}
                                        className="accent-button"
                                    />
                                    :
                                    <Play title="Start"
                                          onClick={onToggle}
                                          className="accent-button"
                                    />
                            }
                            {
                                !isActive ?
                                    <Options
                                        title="Options"
                                        onClick={onSettings}
                                        className="side-button"
                                    />
                                    :
                                    <Stop
                                        title="Reset"
                                        onClick={onReset}
                                        className="side-button"
                                    />
                            }

                        </FlexContainer>
                    </>
                }
            </section>
            {
                // isOnSettings &&
                <section
                    className={classNames('settings', isOnSettings ? 'on-display' : '')}
                    onClick={() => setOnSettings(false)}>
                    <div style={!isOnSettings ? { ...positionStyle, position: "absolute" } : {}}
                         className={classNames('settings__content', isOnSettings ? 'on-display' : '')}>

                    </div>
                </section>
            }
        </>
    )
}
