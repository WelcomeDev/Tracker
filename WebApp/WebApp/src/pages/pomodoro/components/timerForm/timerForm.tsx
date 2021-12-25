import { observer } from 'mobx-react';
import { pomodoroSettingsContext } from '../../../../modules/Pomodoros/hooks/context/pomodoroSettingsContext';
import { TimerConfigure } from '../timerConfigure/timerConfigure';
import { IconButton } from '../../../../components/input/buttons/iconButton/iconButton';
import { Action } from '../../../../components/interfaces/action';
import { Control, UseFormGetValues, UseFormSetValue } from 'react-hook-form/dist/types/form';
import { UseFormRegisterReturn } from 'react-hook-form';
import { UpdatePomodoroParams } from '../../../../modules/Pomodoros/interfaces/updatePomodoroParams';

export interface TimerFormProps {

    isSubmitEnabled: boolean;

    workHoursRegister: UseFormRegisterReturn;
    workMinutesRegister: UseFormRegisterReturn;
    restHorsRegister: UseFormRegisterReturn;
    restMinutesRegister: UseFormRegisterReturn;
    titleRegister: UseFormRegisterReturn;

    setValue: UseFormSetValue<UpdatePomodoroParams>;
    getValues: UseFormGetValues<UpdatePomodoroParams>;
    control: Control<UpdatePomodoroParams>;

    submit: Action;
    cancel: Action;
    remove?: Action;
}

export const TimerForm = observer((props: TimerFormProps) => {

    const {
              getValues, setValue, control,
              submit, cancel, remove,

              workHoursRegister, workMinutesRegister,
              restHorsRegister, restMinutesRegister,
              titleRegister,
              isSubmitEnabled,
          } = props;

    return (
        <form
            className="settings-container"
            onSubmit={e => {
                e.preventDefault();
                submit();
            }}>
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
                        // onClick={save}
                        disabled={!isSubmitEnabled}
                        className={'save-button'}
                        title={'Save'}
                        src={'mdi:check-bold'}/>
                    <IconButton
                        onClick={(e) => {
                            e?.preventDefault();
                            cancel();
                        }}
                        className={'cancel-button'}
                        title={'Cancel'}
                        src={'mdi:close-thick'}/>

                    {
                        remove &&
                        <IconButton
                            onClick={(e) => {
                                e?.preventDefault();
                                remove();
                            }}
                            title={'Remove'}
                            className={'remove-button'}
                            src={'mdi:delete-forever'}/>}
                </section>
            </pomodoroSettingsContext.Provider>
        </form>
    );
});