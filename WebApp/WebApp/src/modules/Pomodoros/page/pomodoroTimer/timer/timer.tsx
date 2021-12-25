import classNames from "classnames";
import { ClassName } from "components/interfaces/className";
import './timer.scss';
import moment from 'moment'
import { formatTime } from "lib/time";
import { DurationDto } from "../../../model/duration";

export interface TimerProps extends ClassName, DurationDto {
    seconds: number;

    percent: number;
}

export function Timer(props: TimerProps) {

    const time = moment({ ...props });

    return (
        <div className={classNames('wrapper', props.className)}>
            <div className="wrapper__outer-circle">
                <div className="wrapper__outer-circle__inner-circle">
                    <div className="wrapper__outer-circle__inner-circle__data-display">
                        <p>{formatTime(time)}</p>
                        <p className="wrapper__outer-circle__inner-circle__data-display__ending-date">
                            {props.percent}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    )
}
