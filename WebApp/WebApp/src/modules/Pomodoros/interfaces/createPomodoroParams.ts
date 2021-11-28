import * as t from 'io-ts';
import { PomodoroEssentialsType } from '../model/pomodoroEssentials';

export interface CreatePomodoroParams extends t.TypeOf<typeof PomodoroEssentialsType>{

}