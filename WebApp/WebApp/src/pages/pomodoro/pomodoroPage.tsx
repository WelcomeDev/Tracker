import './pomodoro.scss';
import {
    PomodoroStoreProvider,
    usePomodoroStore,
} from '../../modules/Pomodoros/hooks/context/pomodoroProvider';
import { Loader } from '../components/loader/loader';
import { PomodoroList } from './pomodoroList/pomodoroList';
import { observer } from 'mobx-react';
import { StickyButton } from '../../components/input/buttons/stickyButton/stickyButton';
import classNames from 'classnames';
import { useState } from 'react';
import { Action } from '../../components/interfaces/action';
import { Modal } from '../../components/modal/modal';
import { CreatePomodoro } from './pomodoroTimer/create/createPomodoro';

export const LoadingResolver = observer(({ onCreateNew }: { onCreateNew: Action }) => {
    const store = usePomodoroStore();

    return (
        store.isLoading ?
            <Loader/>
            :
            store.pomodoroList.length ?
                <PomodoroList
                    pomodoroList={store.pomodoroList}/>
                :
                <h2>There're no pomodoros! Let's create some!</h2>
    );
});

export function PomodoroPage() {

    const [onCreate, setOnCreate] = useState<boolean>(false);

    return (
        <PomodoroStoreProvider>
            <section className={classNames('pomodoro-page', 'content-container')}>
                <LoadingResolver
                    onCreateNew={() => setOnCreate(true)}
                />
            </section>
            <StickyButton
                className={'create-pomodoro-button'}
                icon={'mdi:plus'}
                onClick={() => setOnCreate(true)}
            />
            <Modal
                onClose={() => setOnCreate(false)}
                menuClassName={classNames('create-pomodoro-modal', onCreate && 'on-display')}
                contentClassName={classNames('create-pomodoro-modal__content', onCreate && 'on-display')}
            >
                <CreatePomodoro
                    onClose={() => setOnCreate(false)}/>
            </Modal>
        </PomodoroStoreProvider>
    );
}
