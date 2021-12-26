import './main.scss';
import { AuthProvider, useAuth } from '../modules/Auth/hooks/useAuth';
import { Loader } from './components/loader/loader';
import { ErrorProvider } from '../modules/Main/hooks/context/errorContext';
import { Error } from './components/error/error';
import { BrowserRouter, useRoutes } from 'react-router-dom';
import { routes } from './components/routes/routes';
import { useHistory } from '../components/hooks/useHistory';
import { useEffect } from 'react';
import { appRoutes } from '../config/appRoutes';

const { statistic } = appRoutes;

function AppRoutes() {
    const { isLoading, user } = useAuth();

    const { location, navigate } = useHistory();

    useEffect(
        () => {
            if (location.pathname === '/')
                navigate(statistic);
        },
        []);

    const applicationRoutes = useRoutes(routes(!!user));

    return (
        <>
            {
                isLoading ?
                    <Loader/>
                    :
                    applicationRoutes
            }
        </>
    );
}

export function Main() {
    return (
        <div className={'app-wrapper'}>
            <ErrorProvider>
                <AuthProvider>
                    <BrowserRouter>
                        <AppRoutes/>
                    </BrowserRouter>
                    <Error/>
                </AuthProvider>
            </ErrorProvider>
        </div>
    );
}
