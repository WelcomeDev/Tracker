import * as t from 'io-ts';

export const PomodoroType = t.interface({

});

export interface PomodoroDto extends t.TypeOf<typeof PomodoroType>{
}

export class Pomodoro{

    constructor(pomodoro: PomodoroDto) {
    }
}
