import { Moment } from "moment";

export function formatTime(moment: Moment) {
    return moment.format("hh:mm:ss");
}
