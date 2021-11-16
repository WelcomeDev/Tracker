import { PomodoroTimer } from "./pomodoroTimer/pomodoroTimer";
import './pomodoro.scss';
import { usePomodoro } from "../hooks/usePomodoro";
import { useEffect, useState } from "react";
import { Modal } from "../../../components/modal/modal";
import { Pomodoro } from "../model/pomodoro";

export function PomodoroPage() {

    const { pomodoros } = usePomodoro();

    const [ isModalActive, setModalActive ] = useState(false);
    const [ configuringPomodoro, setConfiguringPomodoro ] = useState<Pomodoro>()

    useEffect(() => {
        if (!isModalActive)
            setConfiguringPomodoro(undefined);
    }, [ isModalActive ])

    useEffect(() => {
        console.log('pomodoro changed')
        if (configuringPomodoro)
            setModalActive(true);
    }, [ configuringPomodoro ])

    return (
        <section className={'pomodoro-page'}>
            {
                pomodoros ?
                    pomodoros.map(p => (<PomodoroTimer
                        key={p.id}
                        pomodoro={p}
                        onConfigure={setConfiguringPomodoro}
                    />))
                    :
                    (<h2>No data</h2>)
            }
        </section>
    )
}
