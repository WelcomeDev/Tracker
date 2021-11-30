import { IconButton } from '../../../../../components/input/iconButton';
import './settingsDisplay.scss';
import { TimerConfigure } from '../timerConfigure/timerConfigure';
import {
    PomodoroTimerConfigureProps,
    usePomodoroTimerConfigure,
} from '../../../../../modules/Pomodoros/hooks/usePomodoroTimerConfigure';
import { pomodoroSettingsContext } from '../../../../../modules/Pomodoros/hooks/context/pomodoroSettingsContext';
import { observer } from 'mobx-react';

export const SettingsDisplay = observer((props: PomodoroTimerConfigureProps) => {

    const {
              save, remove, cancel,
              isSaveEnabled,
              workHoursRegister, workMinutesRegister,
              restHorsRegister, restMinutesRegister,
              titleRegister,
              getValues, setValue,
              control,
          } = usePomodoroTimerConfigure({ ...props });


    return (<form
            className="settings-container"
            onSubmit={e => e.preventDefault()}>
            <pomodoroSettingsContext.Provider
                value={{ getValues, setValue, control }}>
                <p className={'settings-container__title'}>
                    Change timer
                </p>
                <TimerConfigure
                    hoursRegister={workHoursRegister}
                    minutesRegister={workMinutesRegister}
                    title={'Work'}
                    className={'settings-container__work-duration'}/>
                <TimerConfigure
                    hoursRegister={restHorsRegister}
                    minutesRegister={restMinutesRegister}
                    title={'Rest'}
                    className={'settings-container__rest-duration'}/>
                <input
                    type="text"
                    placeholder={'Enter title here'}
                    className={'settings-container__timer-title'}
                    {...titleRegister}/>
                <section
                    className={'settings-container__actions'}>
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
            </pomodoroSettingsContext.Provider>
        </form>
    );
});
