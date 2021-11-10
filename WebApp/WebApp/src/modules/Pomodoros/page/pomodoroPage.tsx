import { PomodoroTimer } from "./pomodoroTimer/pomodoroTimer";
import './pomodoro.scss';
import { usePomodoro } from "../hooks/usePomodoro";

export function PomodoroPage() {

    const { pomodoros } = usePomodoro();

    return (
        <section className={'page-content'}>
            <section className={'page-content__content-holder'}>
                {
                    pomodoros ?
                        pomodoros.map(p => (<PomodoroTimer
                            key={p.id}
                            pomodoroData={p}
                        />))
                        :
                        (<h2>No data</h2>)
                }
            </section>
        </section>
    )
}
