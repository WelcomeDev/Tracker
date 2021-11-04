import classNames from "classnames";
import { ClassName } from "../../../../../components/interfaces/ClassName";
import './timer.scss';
import moment from 'moment'

export interface TimerProps extends ClassName {
    hours: number;
    minutes: number;
    seconds: number;

    percent: number;
}

export function Timer(props: TimerProps) {

    const time = moment({ ...props });

    return (
        <div className={classNames('wrapper', props.className)}>
            <div className="wrapper__outer-circle">
                <div className="wrapper__outer-circle__inner-cicle">
                    {time.format("hh:mm:ss")}
                </div>
            </div>
        </div>
    )
}