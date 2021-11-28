import './error.scss';
import { useErrorHandler } from '../../../modules/Main/hooks/useErrorHandler';
import classNames from 'classnames';

export function Error() {

    const { error, setError } = useErrorHandler();

    return (
        <section
            onClick={() => {
                setError(null);
            }}
            className={classNames('error', error && 'error_display')}
        >
            <p>{error}</p>
            <div className={'error__tracker'}></div>
        </section>
    );
}