import { createContext } from 'react';
import { Control, UseFormGetValues, UseFormSetValue } from 'react-hook-form/dist/types/form';
import { UpdatePomodoroParams } from '../../interfaces/updatePomodoroParams';

export interface PomodoroSettingsService<TType> {
    setValue: UseFormSetValue<TType>;
    getValues: UseFormGetValues<TType>;
    control: Control<TType>;
}

export const pomodoroSettingsContext = createContext({} as PomodoroSettingsService<UpdatePomodoroParams>);
