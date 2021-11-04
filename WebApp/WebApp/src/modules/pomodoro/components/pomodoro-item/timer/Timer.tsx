import { ClassName } from "../../../../../components/interfaces/ClassName";

export interface TimerProps extends ClassName {
    hours: number;
    minutes: number;
    seconds: number;

    percent: number;
}

export function Timer(props: TimerProps) {

    const { hours: hh, minutes: mm, seconds: ss } = props;

    //todo: add circle here
    return (
        <div className={props.className}>
            {`${hh}:${mm}:${ss}`}
        </div>
    )
}