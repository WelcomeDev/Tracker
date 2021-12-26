import * as t from 'io-ts';

export const TagType = t.interface({
    id: t.string,
    name: t.string,
    maxValue: t.union([t.null, t.undefined, t.number]),
});

export interface TagDto extends t.TypeOf<typeof TagType> {
}

export class Tag {
    id: string;
    name: string;

    constructor(params: TagDto) {
        this.id    = params.id;
        this.name = params.name;
    }
}
