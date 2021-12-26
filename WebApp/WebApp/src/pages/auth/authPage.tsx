import './authPage.scss';
import { Password } from './password/password';
import { Username } from './username/username';
import { useAuthHandler } from '../../modules/Auth/hooks/useAuthHandler';

export function AuthPage() {

    const { onSubmit, passwordRegister, loginRegister } = useAuthHandler();

    // todo: add smth on form background. it's kind of empty now
    return (
        <div className={'auth-page-wrapper'}>
            <form
                onSubmit={(e) => {
                    onSubmit();
                    e.preventDefault();
                }}
                className={'auth-form'}
            >
                <p
                    className={'auth-form__title'}
                >
                    Войти
                </p>
                <Username
                    placeholder={'Login'}
                    className={'auth-form__username'}
                    register={loginRegister}
                />
                <Password
                    placeholder={'Password'}
                    className={'auth-form__password'}
                    register={passwordRegister}
                />
                <button
                    className={'auth-form__submit'}
                >
                    Log In
                </button>
            </form>
        </div>
    );
}