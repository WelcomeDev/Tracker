import { IconButton } from "../../../../../../components/input/iconButton";
import './settingsDisplay.scss';
import { TimerConfigure } from "../timerConfigure/timerConfigure";

export function SettingsDisplay() {
    return (
        <form className="settings-container">
            <p
                className={'settings-container__title'}>
                Change timer
            </p>
            <TimerConfigure
                title={'Work'}
                className={'settings-container__work-duration'}/>
            <TimerConfigure
                title={'Rest'}
                className={'settings-container__rest-duration'}/>
            <input
                type="text"
                className={'settings-container__timer-title'}/>
            <section className={'settings-container__actions'}>
                <IconButton
                    className={'save-button'}
                    title={'Save'}
                    src={'mdi:check-bold'}/>
                <IconButton
                    className={'cancel-button'}
                    title={'Cancel'}
                    src={'mdi:close-thick'}/>
                <IconButton
                    title={'Remove'}
                    className={'remove-button'}
                    src={'mdi:delete-forever'}/>
            </section>
        </form>
    )
}
