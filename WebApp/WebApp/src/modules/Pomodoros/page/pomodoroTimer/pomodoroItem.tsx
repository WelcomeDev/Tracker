import { FlexContainer } from 'components/alignment/flexConteiner';
import './pomodoroItem.scss';
import { Timer } from './timer/timer';
import { usePomodoro } from '../../hooks/usePomodoroItem';
import { ReactComponent as Options } from './assets/options.svg';
import { ReactComponent as Pause } from './assets/pause.svg';
import { ReactComponent as Play } from './assets/play.svg';
import { ReactComponent as Stop } from './assets/stop.svg';

export interface PomodoroTimerProps {
    title: string;

}

export function PomodoroTimer(props: PomodoroTimerProps) {

    const {
        onSettings, onReset, onToggle,
        isOnPlay, isActive,
    } = usePomodoro();

    return (
        <section className="pomodoro">
            <p className="pomodoro__title">
                {props.title}
            </p>
            <Timer
                className="pomodoro__timer"
                minutes={30}
                hours={1}
                seconds={0}
                percent={100}/>
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
