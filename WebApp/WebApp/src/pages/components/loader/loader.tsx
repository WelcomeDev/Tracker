import './loader.scss';
import SpinnerLoader from 'react-loader-spinner';
import styles from './loader.module.scss';

export function Loader() {
    return (
        <div
            className={'loader-wrapper'}
        >
            <SpinnerLoader
                type={'TailSpin'}
                color={styles.accent_color}
            />
        </div>
    )
}