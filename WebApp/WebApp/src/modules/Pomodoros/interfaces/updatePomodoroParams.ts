import * as t from 'io-ts';
import { DurationType } from '../model/duration';

const UpdatePomodoroParamsType = t.interface({
    title: t.union([t.string, t.undefined]),
    restDuration: t.union([DurationType, t.undefined]),
    workDuration: t.union([DurationType, t.undefined]),
});

export interface UpdatePomodoroParams extends t.TypeOf<typeof UpdatePomodoroParamsType> {
}