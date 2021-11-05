import { useState } from "react"

export function usePomodoro() {

    const [isOnPlay, setOnPlay] = useState<boolean>(false)
    const [isActive, setIsActive] = useState<boolean>(false)

    function onSettings() {

    }

    function onToggle() {
        if (!isActive)
            setIsActive(true)

        setOnPlay(!isOnPlay);
    }

    function onReset() {
        setIsActive(false);
        setOnPlay(false);
    }

    return {
        onReset, onToggle, onSettings,
        isOnPlay, isActive
    }
}