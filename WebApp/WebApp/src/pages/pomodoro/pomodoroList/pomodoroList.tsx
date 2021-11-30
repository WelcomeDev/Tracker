import { PomodoroTimer } from '../pomodoroTimer/pomodoroTimer';

import './pomodoroList.scss';
import { observer } from 'mobx-react';
import { Pomodoro } from '../../../modules/Pomodoros/model/pomodoro';

export interface PomodoroListProps {
    pomodoroList: Pomodoro[];
}

export const PomodoroList = observer(({ pomodoroList }: PomodoroListProps) => (
    <div
        className={'pomodoro-list'}
    >
        {
            pomodoroList.length ?
                pomodoroList.map(item => (
                    <PomodoroTimer
                        key={item.id}
                        {...item}/>
                ))
                :
                <h2>Let's create new!</h2>
        }
    </div>
));
