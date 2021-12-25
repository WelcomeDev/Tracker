import { RegisterOptions } from 'react-hook-form';

// // Minimum 3 only latin characters
// const CREATE_USERNAME_REGEX = /^[a-zA-Z]{3,}$/;
// // Minimum 8 characters, at least one letter, one number and one special character
// const CREATE_PASSWORD_REGEX = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$/
// export const usernameValidator: RegisterOptions = {
//     required: true,
//     pattern: CREATE_USERNAME_REGEX,
// };
//
// export const passwordValidator: RegisterOptions = {
//     required: true,
//     pattern: CREATE_PASSWORD_REGEX,
// };

export const usernameValidator: RegisterOptions = {
    required: 'Username is empty',
    pattern: {
        message: 'Invalid username',
        value: /[a-zA-Z]+/,
    },
};

export const passwordValidator: RegisterOptions = {
    required: 'Password is empty',
    pattern: {
        message: 'Invalid password',
        value: /[A-Za-z\d@$!%*#?&]+/,
    },
};
