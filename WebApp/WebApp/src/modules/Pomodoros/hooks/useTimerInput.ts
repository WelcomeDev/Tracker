import { useContext, useMemo } from 'react';
import { pomodoroSettingsContext } from './context/pomodoroSettingsContext';
import { UseFormRegisterReturn } from 'react-hook-form';
import { TimeType } from '../../../lib/time';

export type FormTypes =
    | 'restDuration.hours'
    | 'restDuration.minutes'
    | 'workDuration.hours'
    | 'workDuration.minutes';

export function useTimerInput(register: UseFormRegisterReturn) {

    const { getValues, setValue, control } = useContext(pomodoroSettingsContext);

    const name     = useMemo(() => register.name as FormTypes, [register]);
    const timeType = useMemo<TimeType>(() => name.endsWith('minutes') ? 'minute' : 'hour', [name]);
    const maxValue = useMemo<number>(() => timeType === 'minute' ? 59 : 23, [timeType]);

    function increase() {
        let value = getValues(name);
        value     = value < maxValue ? value + 1 : 0;
        setValue(name, value, { shouldValidate: true });
    }

    function decrease() {
        let value = getValues(name);
        value     = value > 0 ? value - 1 : maxValue;
        setValue(name, value, { shouldValidate: true });
    }

    return {
        increase, decrease,
        control,
        name, timeType,
    };
}
