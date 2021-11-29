import * as t from 'io-ts';
import { Tag, TagType } from './tag';
import { UserType } from '../../Main/model/user';
import { StatisticSubject, StatisticSubjectType } from './statisticSubject';
import { StatisticEssentialsType } from './statisticEssentials';
import moment, { Moment } from 'moment';

export const StatisticType = t.intersection([
    t.interface({
        tag: TagType,
        user: UserType,
        date: t.string,
    }),
    StatisticEssentialsType,
]);

export interface StatisticDto extends t.TypeOf<typeof StatisticType> {
}

export class Statistic {
    id: string;
    value: number;
    subject: StatisticSubject;
    date: Moment;
    tag: Tag;

    constructor(params: StatisticDto) {
        this.date    = moment(params.date);
        this.tag     = new Tag(params.tag);
        this.id      = params.id;
        this.value   = params.value;
        this.subject = new StatisticSubject(params.subject);
    }
}
