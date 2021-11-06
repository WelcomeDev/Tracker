import { PomodoroTimer } from "./pomodoroTimer/pomodoroTimer";
import './pomodoro.scss';

export function Pomodoro() {

    const test = [ 1, 2, 3, 4, 5, 6, 7, 8];
    return (
        <section className={'page-content'}>
            <section className={'page-content__content-holder'}>
                {test.map(x => (<PomodoroTimer
                    id={'some-test-id'}
                    title={'Work'}
                    workDuration={{
                        hours: 1,
                        minutes: 1,
                    }}
                    restDuration={{
                        hours: 0,
                        minutes: 15,
                    }}
                />))}
            </section>
        </section>
    )
}
