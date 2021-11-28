import { useError } from '../../Main/hooks/context/errorContext';
import { FieldErrors, useForm } from 'react-hook-form';
import { AuthParams } from '../interfaces/authParams';
import { login } from '../actions/authActions';
import { passwordValidator, usernameValidator } from '../model/validators';

export function useAuthHandler() {
    const { setError } = useError();

    const { handleSubmit, register } = useForm<AuthParams>({
        mode: 'onSubmit',
        reValidateMode: 'onChange',
        shouldFocusError: true,
    });

    function displayError(errors: FieldErrors<AuthParams>) {
        if (errors.password?.message) {
            setError(errors.password.message);
            return;
        }

        if (errors?.login?.message) {
            setError(errors?.login?.message);
            return;
        }
    }

    function onSubmit() {
        handleSubmit(
            (data) => login(data),
            (errors) => displayError(errors),
        )();
    }

    return {
        passwordRegister: register('password', passwordValidator),
        loginRegister: register('login', usernameValidator),
        onSubmit,
    };
}