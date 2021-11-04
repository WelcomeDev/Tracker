import { useState } from "react"

export function usePomodoro() {

    const [isOnPlay, setOnPlay] = useState<boolean>(false)

    function onSettings() {

    }

    function onToggle() {

    }

    function onReset() {

    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay,
    }
}