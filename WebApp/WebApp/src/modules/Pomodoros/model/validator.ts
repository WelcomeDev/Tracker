import { RegisterOptions } from 'react-hook-form/dist/types/validator';

export const minuteRegisterOptions: RegisterOptions = {
    min: {
        value: 0,
        message: `Time can't be less than 0`,
    },
    max: {
        value: 59,
        message: `You can't exceed 59 minutes`,
    },
    maxLength: 2,
    minLength: 2,
    valueAsNumber: true,
};

export const hoursRegisterOptions: RegisterOptions = {
    min: {
        value: 0,
        message: `Time can't be less than 0`,
    },
    max: {
        value: 23,
        message: `You can't exceed 23 hours`,
    },
    maxLength: 2,
    minLength: 2,
    valueAsNumber: true,
};

export const titleRegisterOptions: RegisterOptions = {
    required: 'Title is required',
    pattern: {
        message: 'Should be maximum 20 latin letters',
        value: /^[A-Za-z]{1,20}$/,
    },
};
