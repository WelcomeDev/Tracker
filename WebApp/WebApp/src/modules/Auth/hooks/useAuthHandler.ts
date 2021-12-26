import { useError } from '../../Main/hooks/context/errorContext';
import { FieldErrors, useForm } from 'react-hook-form';
import { AuthParams } from '../interfaces/authParams';
import { passwordValidator, usernameValidator } from '../model/validators';
import { useAuth } from './useAuth';
import { useNavigate } from 'react-router-dom';
import { appRoutes } from '../../../config/appRoutes';

export function useAuthHandler() {
    const { setError } = useError();
    const { login } = useAuth();
    const navigate = useNavigate();
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
                login(data.username, data.password)
                    .then(() => {
                        navigate(appRoutes.statistic);
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