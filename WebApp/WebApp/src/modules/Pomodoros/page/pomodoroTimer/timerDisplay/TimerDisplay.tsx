import { Timer } from "../timer/timer";
import { FlexContainer } from "../../../../../components/alignment/flexConteiner";
import { ReactComponent as Pause } from "../assets/pause.svg";
import { ReactComponent as Play } from "../assets/play.svg";
import { ReactComponent as Options } from "../assets/options.svg";
import { ReactComponent as Stop } from "../assets/stop.svg";

export interface TimerDisplayProps {

}

export function TimerDisplay(props: TimerDisplayProps) {
    return (
        <>
            {/*<p className="pomodoro__title">*/}
            {/*    <span>{title}</span>*/}
            {/*    <span style={{ opacity: 0.6 }}> {mode}</span>*/}
            {/*</p>*/}
            {/*<Timer*/}
            {/*    className="pomodoro__timer"*/}
            {/*    {...duration}/>*/}
            {/*<FlexContainer*/}
            {/*    className="pomodoro__actions"*/}
            {/*    justifyContent="space-around"*/}
            {/*>*/}
            {/*    {*/}
            {/*        isOnPlay ?*/}
            {/*            <Pause*/}
            {/*                title="Pause"*/}
            {/*                onClick={onToggle}*/}
            {/*                className="accent-button"*/}
            {/*            />*/}
            {/*            :*/}
            {/*            <Play title="Start"*/}
            {/*                  onClick={onToggle}*/}
            {/*                  className="accent-button"*/}
            {/*            />*/}
            {/*    }*/}
            {/*    {*/}
            {/*        !isActive ?*/}
            {/*            <Options*/}
            {/*                title="Options"*/}
            {/*                onClick={onSettings}*/}
            {/*                className="side-button"*/}
            {/*            />*/}
            {/*            :*/}
            {/*            <Stop*/}
            {/*                title="Reset"*/}
            {/*                onClick={onReset}*/}
            {/*                className="side-button"*/}
            {/*            />*/}
            {/*    }*/}

            {/*</FlexContainer>*/}
        </>
    )
}
