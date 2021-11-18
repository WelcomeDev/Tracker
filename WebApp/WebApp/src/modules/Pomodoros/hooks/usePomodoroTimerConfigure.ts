import { useEffect, useState } from "react";
import { Action } from "../../../components/interfaces/action";
import { Pomodoro } from "../model/pomodoro";

export interface PomodoroTimerConfigureProps {
    pomodoro: Pomodoro;
    onClose: Action;
}

export function usePomodoroTimerConfigure({
                                              pomodoro,
                                              onClose,
                                          }: PomodoroTimerConfigureProps) {

    const [ title, setTitle ] = useState(pomodoro.title);
    const [isTitleValid, setTitleValid] = useState<boolean>(false);

    const [isSaveEnabled, setSaveEnabled] = useState<boolean>(false);

    useEffect(()=>{
        setSaveEnabled(isTitleValid);
    }, [isTitleValid])

    function save() {
        //todo: call storage edit
        onClose();
    }

    function remove() {
        //todo: call storage and remove
        onClose();
    }

    function cancel() {
        setTitle(pomodoro.title);
        //todo: set durations back
        onClose();
    }

    return {
        title, setTitle,
        save, remove, cancel,
        isTitleValid,
        isSaveEnabled,
    }
}
