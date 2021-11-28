import './main.scss';
import { useAuth } from '../modules/Auth/hooks/useAuth';
import { Loader } from './components/loader/loader';
import { AppRoutes } from './components/routes/appRoutes';

export function Main() {
    const { isLoading } = useAuth();

    return (
        <div className={'app-wrapper'}>
            {
                isLoading ?
                    <Loader/>
                    :
                    <AppRoutes/>
            }
        </div>
    );
}
