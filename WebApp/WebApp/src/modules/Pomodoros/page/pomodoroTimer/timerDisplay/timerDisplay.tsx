import { Timer } from "../timer/timer";
import { FlexContainer } from "../../../../../components/alignment/flexConteiner";
import { UsePomodoroTimerService } from "../../../hooks/usePomodoroTimer";
import './timerDisplay.scss';
import { IconButton } from "../../../../../components/input/iconButton";

export interface TimerDisplayProps extends UsePomodoroTimerService {
    title: string;
}

export function TimerDisplay(props: TimerDisplayProps) {

    const {
        duration, title,
        mode,
        isOnPlay, onToggle, isActive, onReset,
        onSettings,
    } = props;

    return (
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
                <IconButton
                    onClick={onToggle}
                    title={isOnPlay ? 'Pause' : 'Play'}
                    src={isOnPlay ? 'mdi:pause-circle-outline' : 'mdi:play'}
                    className="accent-button"/>

                <IconButton
                    title={isActive ? 'Reset' : 'Options'}
                    onClick={isActive ? onReset : onSettings}
                    src={isActive ? 'mdi:stop-circle-outline' : 'mdi:cog'}
                    className="side-button"
                />
            </FlexContainer>
        </>
    )
}
