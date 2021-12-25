import * as t from 'io-ts';

export const DurationType = t.interface({
    hours: t.number,
    minutes: t.number,
});

export interface DurationDto extends t.TypeOf<typeof DurationType> {

}

export class Duration {
    private hours: number;
    private minutes: number;

    constructor(duration: DurationDto) {
        this.hours = duration.hours;
        this.minutes = duration.minutes;
    }
}
