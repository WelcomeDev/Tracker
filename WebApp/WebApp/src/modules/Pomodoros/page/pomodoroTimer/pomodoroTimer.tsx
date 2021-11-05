import { FlexContainer } from 'components/alignment/flexConteiner';
import './pomodoroItem.scss';
import { Timer } from './timer/timer';
import { usePomodoroTimer } from '../../hooks/usePomodoroTimer';
import { ReactComponent as Options } from './assets/options.svg';
import { ReactComponent as Pause } from './assets/pause.svg';
import { ReactComponent as Play } from './assets/play.svg';
import { ReactComponent as Stop } from './assets/stop.svg';
import { PomodoroDto } from "../../model/pomodoro";

export interface PomodoroTimerProps extends PomodoroDto {
}

export function PomodoroTimer(props: PomodoroTimerProps) {

    const {
        onSettings, onReset, onToggle,
        isOnPlay, isActive,
        duration, percent,
    } = usePomodoroTimer({ pomodoro: props as PomodoroDto });

    return (
        <section className="pomodoro">
            <p className="pomodoro__title">
                {props.title}
            </p>
            <Timer
                className="pomodoro__timer"
                {...duration}
                percent={percent}/>
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
        </section>
    )
}
