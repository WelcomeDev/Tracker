import { PomodoroTimer } from "./pomodoroTimer/pomodoroTimer";
import './pomodoro.scss';
import { usePomodoro } from "../hooks/usePomodoro";
import { useEffect, useState } from "react";
import { Modal } from "../../../components/modal/modal";
import { Pomodoro } from "../model/pomodoro";

export function PomodoroPage() {

    const { pomodoros } = usePomodoro();
    
    return (
        <section className={'pomodoro-page'}>
            {
                pomodoros ?
                    pomodoros.map(p => (<PomodoroTimer
                        key={p.id}
                        pomodoro={p}
                    />))
                    :
                    (<h2>No data</h2>)
            }
        </section>
    )
}
