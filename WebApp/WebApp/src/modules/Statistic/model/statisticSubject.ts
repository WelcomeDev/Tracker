import * as t from 'io-ts';

export const StatisticSubjectType = t.interface({
    title: t.string,
    color: t.union([t.string, t.undefined, t.null]),
});

export interface StatisticSubjectDto extends t.TypeOf<typeof StatisticSubjectType> {
}

export class StatisticSubject {
    title: string;
    color: string | null;

    constructor(params: StatisticSubjectDto) {
        this.title = params.title;
        this.color = params.title ?? null;
    }
}
