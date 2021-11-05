import { FlexContainer } from 'components/alignment/FlexConteiner';
import './pomodoro-item.scss';
import { Timer } from './timer/Timer';
import { usePomodoro } from './usePomodoroItem';
import { ReactComponent as Options } from './assets/options.svg';
import { ReactComponent as Pause } from './assets/pause.svg';
import { ReactComponent as Play } from './assets/play.svg';
import { ReactComponent as Stop } from './assets/stop.svg';

export function Pomodoro() {

    const {
        onSettings, onReset, onToggle,
        isOnPlay, isActive,
    } = usePomodoro();

    return (
        <section className="pomodoro">
            <p className="pomodoro__title">
                Just some title
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
