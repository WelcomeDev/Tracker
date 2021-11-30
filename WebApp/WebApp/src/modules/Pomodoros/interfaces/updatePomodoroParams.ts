import * as t from 'io-ts';
import { DurationType } from '../model/duration';

const UpdatePomodoroParamsType = t.interface({
    title: t.string,
    restDuration: DurationType,
    workDuration: DurationType,
});

export interface UpdatePomodoroParams extends t.TypeOf<typeof UpdatePomodoroParamsType> {
}