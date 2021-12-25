import { useError } from './context/errorContext';
import { useEffect, useState } from 'react';

const SHOW_ERROR_DURATION = 2000;

export function useErrorHandler() {
    const { error, setError } = useError();

    const [percent, setPercent] = useState<number>(0);

    useEffect(
        () => {
            error ? setPercent(100) : setPercent(0);
        },
        [error],
    );

    useEffect(
        () => {
            if (error)
                setTimeout(() => setError(null), SHOW_ERROR_DURATION);
        }
        , [error]);

    return {
        error,
        setError,
        percent,
    };
}