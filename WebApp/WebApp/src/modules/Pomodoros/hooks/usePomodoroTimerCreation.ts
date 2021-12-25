import { Action } from '../../../components/interfaces/action';
import { useForm } from 'react-hook-form';
import { usePomodoroStore } from './context/pomodoroProvider';
import { CreatePomodoroParams } from '../interfaces/createPomodoroParams';
import { hoursRegisterOptions, minuteRegisterOptions, titleRegisterOptions } from '../model/validator';
import { useMemo } from 'react';

export function usePomodoroTimerCreation({ onClose }: { onClose: Action }) {

    const creationDefaultValues = useMemo(() => ({
            workDuration: {
                hours: 0,
                minutes: 25,
            },
            restDuration: {
                hours: 0,
                minutes: 5,
            },
            title: 'Title'
        }),
        []);

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
          } = useForm<CreatePomodoroParams>({
        reValidateMode: 'onChange',
        shouldFocusError: true,
        mode: 'onBlur',
        defaultValues: creationDefaultValues,
        shouldUseNativeValidation: true,
    });

    const { createPomodoro } = usePomodoroStore();

    function cancel() {
        reset(creationDefaultValues);
        onClose();
    }

    function submit() {
        // todo: handle errors
        // todo: add message handler to write 'ok'
        handleSubmit(
            (params: CreatePomodoroParams) =>
                createPomodoro(params)
                    .then(onClose)
                    .catch((error) => console.log(error)),
            (error) => console.log(error),
        )();
    }

    return {
        cancel, submit,
        isSubmitEnabled: isValid,
        workHoursRegister: register('workDuration.hours', hoursRegisterOptions),
        restHorsRegister: register('restDuration.hours', hoursRegisterOptions),
        workMinutesRegister: register('workDuration.minutes', minuteRegisterOptions),
        restMinutesRegister: register('restDuration.minutes', minuteRegisterOptions),
        titleRegister: register('title', titleRegisterOptions),
        getValues, setValue,
        control,
    };
}