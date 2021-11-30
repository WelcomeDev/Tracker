import './pomodoro.scss';
import {
    PomodoroStoreProvider,
    usePomodoroStore,
} from '../../modules/Pomodoros/hooks/context/pomodoroProvider';
import { Loader } from '../components/loader/loader';
import { PomodoroList } from './pomodoroList/pomodoroList';
import { observer } from 'mobx-react';
import { useEffect } from 'react';

export const LoadingResolver = observer(() => {
    const store = usePomodoroStore();
    useEffect(() => {
        store.loadPomodoroList();
    }, []);

    return (
        store.isLoading ?
            <Loader/>
            :
            <PomodoroList
                pomodoroList={store.pomodoroList}/>
    );
});

export function PomodoroPage() {
    return (
        <section className={'pomodoro-page'}>
            <PomodoroStoreProvider>
                <LoadingResolver/>
            </PomodoroStoreProvider>
        </section>
    );
}
