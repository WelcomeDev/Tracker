import { FlexContainer } from '../../../../components/alignment/FlexConteiner';
import { OptionItem } from './option-item/OptionItem';
import './pomodoro-item.scss';
import { Timer } from './timer/Timer';
import { usePomodoro } from './usePomodoroItem';

export function Pomodoro() {

    const {
        onSettings, onReset,
        isOnPlay
    } = usePomodoro();

    return (
        <section className='pomodoro'>
            <p className='pomodoro__title'>
                Just some title
            </p>
            <Timer
                className='pomodoro__timer'
                minutes={30}
                hours={1}
                seconds={0}
                percent={100} />
            <FlexContainer
                className='pomodoro__actions'
                justifyContent='space-around'
            >
                {
                    isOnPlay &&
                    <OptionItem
                        title='Options'
                        onClick={onSettings}
                        iconPath='mdi:cog' />
                }
                <OptionItem
                    title='Options'
                    onClick={onSettings}
                    iconPath={`mdi:${isOnPlay ? 'pause-circle-outline' : 'play-circle-outline'}`} />
                {
                    !isOnPlay &&
                    <OptionItem
                        title='Reset'
                        onClick={onReset}
                        iconPath='mdi:refresh' />
                }

            </FlexContainer>
        </section>
    )
}