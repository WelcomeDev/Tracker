import * as t from 'io-ts';
import { DurationType } from "./duration";

export const PomodoroEssentialsType = t.interface({
    title: t.string,
    restDuration: DurationType,
    workDuration: DurationType,
});

export interface PomodoroEssentialsDto extends t.TypeOf<typeof PomodoroEssentialsType>{

}
