import { usePomodoroStore } from '../../../modules/Pomodoros/hooks/context/pomodoroProvider';
import { PomodoroTimer } from '../pomodoroTimer/pomodoroTimer';

import './pomodoroList.scss';

export function PomodoroList() {
    const { store: { pomodoroList } } = usePomodoroStore();

    return (
        <div
            className={'pomodoro-list'}
        >
            {
                pomodoroList.length ?
                    pomodoroList.map(item => (
                        <PomodoroTimer
                            pomodoro={item}/>
                    ))
                    :
                    <h2>Let's create new!</h2>
            }
        </div>
    );
}