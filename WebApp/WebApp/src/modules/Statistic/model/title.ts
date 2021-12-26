import * as t from 'io-ts';

export const StatisticSubjectType = t.interface({
    id: t.string,
    title: t.string,
    color: t.union([t.string, t.undefined, t.null]),
});

export interface StatisticSubjectDto extends t.TypeOf<typeof StatisticSubjectType> {
}

export class Title {
    id: string;
    name: string;
    color: string;

    constructor(params: StatisticSubjectDto) {
        this.id = params.id;
        this.name = params.title;
        this.color = params.title ?? '#fff';
    }
}
