import './main.scss';
import { useAuth } from '../modules/Auth/hooks/useAuth';
import { Loader } from './components/loader/loader';
import { AppRoutes } from './components/routes/appRoutes';
import { ErrorProvider } from '../modules/Main/hooks/context/errorContext';

export function Main() {
    const { isLoading } = useAuth();

    return (
        <div className={'app-wrapper'}>
            <ErrorProvider>
                {
                    isLoading ?
                        <Loader/>
                        :
                        <AppRoutes/>
                }
            </ErrorProvider>
        </div>
    );
}
