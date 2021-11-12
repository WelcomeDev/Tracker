import { useEffect, useState } from "react";
import { getAll } from "../action/pomodoroCrudActions";
import { Pomodoro } from "../model/pomodoro";
import { mockData } from "./mockData";

export function usePomodoro() {

    const [ pomodoros, setPomodoros ] = useState<Pomodoro[]>();

    // useEffect(() => {
    //     getAll()
    //         .then(x => setPomodoros(x));
    // }, [])

    useEffect(() => {
        setPomodoros(mockData.map(x => new Pomodoro(x)));
        getAll();
    }, [])

    return {
        pomodoros,
    }
}
