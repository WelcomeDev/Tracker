import { FlexContainer } from 'components/alignment/flexConteiner';
import './pomodoroItem.scss';
import { Timer } from './timer/timer';
import { usePomodoroTimer } from '../../hooks/usePomodoroTimer';
import { ReactComponent as Options } from './assets/options.svg';
import { ReactComponent as Pause } from './assets/pause.svg';
import { ReactComponent as Play } from './assets/play.svg';
import { ReactComponent as Stop } from './assets/stop.svg';
import { Pomodoro } from "../../model/pomodoro";

export interface PomodoroTimerProps {
    pomodoroData: Pomodoro;
}

export function PomodoroTimer(props: PomodoroTimerProps) {

    const { title } = props.pomodoroData;

    const {
        onSettings, onReset, onToggle,
        isOnPlay, isActive,
        duration,
        mode,
    } = usePomodoroTimer(props.pomodoroData);

    return (
        <section className="pomodoro">
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
        </section>
    )
}
