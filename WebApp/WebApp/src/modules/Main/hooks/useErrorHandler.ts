import { useError } from './context/errorContext';
import { useEffect, useState } from 'react';

const SHOW_ERROR_DURATION = 3000;

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
            setTimeout(() => setError(null), SHOW_ERROR_DURATION);
        }
        , []);

    return {
        error,
        setError,
        percent,
    };
}