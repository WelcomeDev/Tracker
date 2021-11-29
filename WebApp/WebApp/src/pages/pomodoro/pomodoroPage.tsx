import './pomodoro.scss';
import { PomodoroStoreProvider, usePomodoroStore } from '../../modules/Pomodoros/hooks/context/pomodoroProvider';
import { Loader } from '../components/loader/loader';
import { PomodoroList } from './pomodoroList/pomodoroList';

function LoadingResolver() {
    const { isLoading } = usePomodoroStore();

    return (
        isLoading ?
            <Loader/>
            :
            <PomodoroList/>
    );
}

export function PomodoroPage() {
    return (
        <PomodoroStoreProvider>
            <section className={'pomodoro-page'}>
                <LoadingResolver/>
            </section>
        </PomodoroStoreProvider>
    );
}
