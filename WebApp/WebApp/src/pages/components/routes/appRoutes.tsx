import { BrowserRouter, Outlet, Route, Routes } from 'react-router-dom';
import { AuthPage } from '../../auth/authPage';
import { Header } from '../header/header';
import classNames from 'classnames';
import { PomodoroPage } from '../../pomodoro/pomodoroPage';
import { StatisticPage } from '../../statistic/statisticPage';
import { appRoutes } from '../../../config/appRoutes';
import { NotFound } from './notFound/notFound';
import { useEffect } from 'react';
import { useHistory } from '../../../components/hooks/useHistory';

const { pomodoro, statistic, auth } = appRoutes;

function AppWrapper() {

    const { location, navigate } = useHistory();

    useEffect(
        () => {
            if (location.pathname === '/')
                navigate(statistic);
        },
        []);

    return (
        <>
            <Header/>
            <div className={classNames('page-content')}>
                <Outlet/>
            </div>
        </>
    );
}

export function AppRoutes() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path={auth} element={<AuthPage/>}/>
                <Route path={'/'} element={<AppWrapper/>}>
                    <Route
                        path={statistic}
                        element={<StatisticPage/>}
                    />
                    <Route
                        path={pomodoro}
                        element={<PomodoroPage/>}
                    />
                </Route>
                <Route path={'*'} element={<NotFound/>}/>
            </Routes>
        </BrowserRouter>
    );
}