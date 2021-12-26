import './main.scss';
import { useAuth } from '../modules/Auth/hooks/useAuth';
import { Loader } from './components/loader/loader';
// import { AppRoutes } from './components/routes/appRoutes';
import { ErrorProvider } from '../modules/Main/hooks/context/errorContext';
import { Error } from './components/error/error';
import { Outlet, useRoutes } from 'react-router-dom';
import { routes } from './components/routes/routes';
import { useHistory } from '../components/hooks/useHistory';
import { useEffect } from 'react';
import { Header } from './components/header/header';
import classNames from 'classnames';
import { appRoutes } from '../config/appRoutes';

const { statistic } = appRoutes;

function AppRoutes() {
    const { isLoading } = useAuth();
    const { location, navigate } = useHistory();

    useEffect(
        () => {
            if (location.pathname === '/')
                navigate(statistic);
        },
        []);

    const applicationRoutes = useRoutes(routes(isLoading));

    return (
        <>
            <Header/>
            <div className={classNames('page-content')}>
                {/*<Outlet/>*/}
                {applicationRoutes}
            </div>
        </>
    );
}

export function Main() {
    const { isLoading } = useAuth();
    useRoutes(routes(isLoading));

    return (
        <div className={'app-wrapper'}>
            <ErrorProvider>
                {
                    isLoading ?
                        <Loader/>
                        :
                        <AppRoutes/>
                }
                <Error/>
            </ErrorProvider>
        </div>
    );
}
