import * as t from 'io-ts';
import { StatisticSubject, StatisticSubjectType } from './statisticSubject';

export const StatisticEssentialsType = t.interface({
    id: t.string,
    subject: StatisticSubjectType,
    value: t.number,
});

export interface StatisticEssentialsDto extends t.TypeOf<typeof StatisticEssentialsType> {
}

export class StatisticEssentials {
    subject: StatisticSubject;
    value: number;

    constructor(params: StatisticEssentialsDto) {
        this.subject = new StatisticSubject(params.subject);
        this.value   = params.value;
    }
}
