import * as t from 'io-ts';

export const UserType = t.interface({
    id: t.string,
});

export interface UserDto extends t.TypeOf<typeof UserType>{
}


