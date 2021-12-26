import { useError } from '../../Main/hooks/context/errorContext';
import { FieldErrors, useForm } from 'react-hook-form';
import { AuthParams } from '../interfaces/authParams';
import { login } from '../actions/authActions';
import { passwordValidator, usernameValidator } from '../model/validators';
import { useAuth } from './useAuth';

export function useAuthHandler() {
    const { setError } = useError();
    const {} = useAuth();
    const { handleSubmit, register } = useForm<AuthParams>({
        mode: 'onSubmit',
        reValidateMode: 'onChange',
        shouldFocusError: true,
    });

    function displayError(errors: FieldErrors<AuthParams>) {
        if (errors?.username?.message) {
            setError(errors?.username?.message);
            return;
        }

        if (errors.password?.message) {
            setError(errors.password.message);
            return;
        }
    }

    function onSubmit() {
        handleSubmit(
            async (data) => {
                // todo: add loading here with dots under 'Log in' button
                login(data)
                    .then(() => {
                        // todo: navigate to '/'
                    })
                    .catch(() => setError('Invalid username or password!'));
            },
            (errors) => displayError(errors),
        )();
    }

    return {
        loginRegister: register('username', usernameValidator),
        passwordRegister: register('password', passwordValidator),
        onSubmit,
    };
}