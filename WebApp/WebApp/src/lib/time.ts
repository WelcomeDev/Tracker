import { Moment } from "moment";

export function formatTime(moment: Moment) {
    if (moment.hours() === 0)
        return moment.format("00:mm:ss");

    return moment.format("hh:mm:ss");
}

export function doubleDigitTime(time: number): string {
    if (time / 10 >= 1)
        return String(time);

    return `0${time}`;
}

export function toSeconds(seconds: number, minutes = 0, hours = 0) {
    return seconds + minutes * 60 + hours * 60 * 60;
}
