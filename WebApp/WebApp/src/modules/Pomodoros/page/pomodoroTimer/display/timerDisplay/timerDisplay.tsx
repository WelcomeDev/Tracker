import { Timer } from "../timer/timer";
import { FlexContainer } from "../../../../../../components/alignment/flexConteiner";
import { TimerMode, UsePomodoroTimerService } from "../../../../hooks/usePomodoroTimer";
import './timerDisplay.scss';
import { IconButton } from "../../../../../../components/input/iconButton";
import { Icon } from "@iconify/react";

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
            <div className="pomodoro__title">
                <p>{title}</p>
                <div title={`Pomodoro status: ${mode}`}>
                    <Icon icon={mode === TimerMode.Work ? 'mdi:briefcase' : 'mdi:sleep'}/>
                </div>
            </div>
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
