import { Action } from '../../../components/interfaces/action';
import { Pomodoro } from '../model/pomodoro';
import { usePomodoroStore } from './context/pomodoroProvider';
import { useForm } from 'react-hook-form';
import { UpdatePomodoroParams } from '../interfaces/updatePomodoroParams';
import { hoursRegisterOptions, minuteRegisterOptions, titleRegisterOptions } from '../model/validator';

export interface PomodoroTimerConfigureProps {
    pomodoro: Pomodoro;
    onClose: Action;
}

export function usePomodoroTimerConfigure({
                                              pomodoro,
                                              onClose,
                                          }: PomodoroTimerConfigureProps) {
    const {
              register,
              reset,
              control,
              handleSubmit,
              getValues,
              setValue,
              formState: {
                  errors,
                  isValid,
              },
          } = useForm<UpdatePomodoroParams>({
        reValidateMode: 'onChange',
        shouldFocusError: true,
        mode: 'onBlur',
        defaultValues: {
            restDuration: pomodoro.restDuration,
            workDuration: pomodoro.workDuration,
            title: pomodoro.title,
        },
        shouldUseNativeValidation: true,
    });

    const { updatePomodoro, removePomodoro } = usePomodoroStore();

    function save() {
        // todo: handle errors
        handleSubmit(
            (params: UpdatePomodoroParams) =>
                updatePomodoro(pomodoro, params)
                    .then(() => onClose())
                    .catch((error) => console.log(error)),
            (error) => console.log(error),
        )();
    }

    function remove() {
        removePomodoro(pomodoro)
            .then(() => onClose());
    }

    function cancel() {
        reset();
        onClose();
    }

    return {
        save, remove, cancel,
        isSaveEnabled: isValid,
        workHoursRegister: register('workDuration.hours', hoursRegisterOptions),
        restHorsRegister: register('restDuration.hours', hoursRegisterOptions),
        workMinutesRegister: register('workDuration.minutes', minuteRegisterOptions),
        restMinutesRegister: register('restDuration.minutes', minuteRegisterOptions),
        titleRegister: register('title', titleRegisterOptions),
        getValues, setValue,
        control
    };
}
