import { IconButton } from "../../../../../components/input/iconButton";
import './settingsDisplay.scss';
import { TimerConfigure } from "../timerConfigure/timerConfigure";
import { PomodoroTimerConfigureProps, usePomodoroTimerConfigure } from "../../../../../modules/Pomodoros/hooks/usePomodoroTimerConfigure";
import { useForm } from "react-hook-form";
import { Pomodoro } from "../../../../../modules/Pomodoros/model/pomodoro";

export function SettingsDisplay(props: PomodoroTimerConfigureProps) {

    const {
        save, remove, cancel,
        isSaveEnabled,
    } = usePomodoroTimerConfigure({ ...props })

    const {
        register,
        setValue,
    } = useForm<Pomodoro>();

    return (
        <form
            className="settings-container"
            onSubmit={e => e.preventDefault()}
        >
            <p className={'settings-container__title'}>
                Change timer
            </p>
            <TimerConfigure
                minutesRegister={
                    {
                        initialValue: props.pomodoro.workDuration.minutes,
                        setTime: (val) => setValue('workDuration.hours', val),
                        maxValue: 60,
                    }
                }
                hoursRegister={
                    {
                        initialValue: props.pomodoro.workDuration.hours,
                        setTime: (val) => setValue('workDuration.hours', val),
                        maxValue: 24,
                    }
                }
                title={'Work'}
                className={'settings-container__work-duration'}/>
            <TimerConfigure
                minutesRegister={
                    {
                        initialValue: props.pomodoro.restDuration.minutes,
                        setTime: (val) => setValue('restDuration.hours', val),
                        maxValue: 60,
                    }
                }
                hoursRegister={
                    {
                        initialValue: props.pomodoro.restDuration.hours,
                        setTime: (val) => setValue('restDuration.hours', val),
                        maxValue: 24,
                    }
                }
                title={'Rest'}
                className={'settings-container__rest-duration'}/>
            <input
                {...register('title',
                    {
                        value: props.pomodoro.title,
                        required: true,
                        pattern: /^[A-Za-z]+$/i,
                    })}
                type="text"
                placeholder={'Enter title here'}
                className={'settings-container__timer-title'}/>
            <section className={'settings-container__actions'}>
                <IconButton
                    onClick={save}
                    disabled={!isSaveEnabled}
                    className={'save-button'}
                    title={'Save'}
                    src={'mdi:check-bold'}/>
                <IconButton
                    onClick={cancel}
                    className={'cancel-button'}
                    title={'Cancel'}
                    src={'mdi:close-thick'}/>
                <IconButton
                    onClick={remove}
                    title={'Remove'}
                    className={'remove-button'}
                    src={'mdi:delete-forever'}/>
            </section>
        </form>
    )
}
