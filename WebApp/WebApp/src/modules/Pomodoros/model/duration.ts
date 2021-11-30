import * as t from 'io-ts';
import { action, makeAutoObservable, observable } from 'mobx';

export const DurationType = t.interface({
    hours: t.number,
    minutes: t.number,
});

export interface DurationDto extends t.TypeOf<typeof DurationType> {

}

export class Duration {
    hours: number;
    minutes: number;

    constructor(duration: DurationDto) {
        this.hours   = duration.hours;
        this.minutes = duration.minutes;
    }
}
