import { Navigate, RouteObject } from 'react-router-dom';
import { appRoutes } from '../../../config/appRoutes';
import { AuthPage } from '../../auth/authPage';
import { PomodoroPage } from '../../pomodoro/pomodoroPage';
import { StatisticPage } from '../../statistic/statisticPage';
import { NotFound } from './notFound/notFound';
import { AppContentPage } from '../appContentPage/appContentPage';

const { pomodoro, statistic, auth } = appRoutes;

export const routes = (isLoggedIn: boolean): RouteObject[] => [
    {
        path: auth,
        element: <AuthPage/>,
    },
    {
        path: pomodoro,
        element: isLoggedIn
            ? <AppContentPage page={<PomodoroPage/>}/>
            : <Navigate to={auth}/>,
    },
    {
        path: statistic,
        element: isLoggedIn
            ? <AppContentPage page={<StatisticPage/>}/>
            : <Navigate to={auth}/>,
    },
    {
        path: '*',
        element: <NotFound/>,
    },
];