import classNames from "classnames";
import { ClassName } from "components/interfaces/className";
import './timer.scss';
import moment from 'moment'
import { formatTime } from "lib/formatMoment";
import { DurationDto } from "../../../model/duration";

export interface TimerProps extends ClassName, DurationDto{
    seconds: number;

    percent: number;
}

export function Timer(props: TimerProps) {

    const time = moment({ ...props });

    return (
        <div className={classNames('wrapper', props.className)}>
            <div className="wrapper__outer-circle">
                <div className="wrapper__outer-circle__inner-circle">
                    {formatTime(time)}
                </div>
            </div>
        </div>
    )
}
