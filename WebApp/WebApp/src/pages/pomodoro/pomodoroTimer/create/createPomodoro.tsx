import { usePomodoroTimerCreation } from '../../../../modules/Pomodoros/hooks/usePomodoroTimerCreation';
import { Action } from '../../../../components/interfaces/action';
import { TimerForm } from '../../components/timerForm/timerForm';

export function CreatePomodoro({ onClose }: { onClose: Action }) {
    const creation = usePomodoroTimerCreation({ onClose });

    return (
       <TimerForm
           {...creation}
       />
    );
}