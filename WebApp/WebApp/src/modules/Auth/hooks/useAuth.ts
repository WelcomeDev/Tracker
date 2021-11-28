import { useEffect, useMemo, useState } from 'react';

export function useAuth() {
    const [isLoading, setIsLoading] = useState(true);

    useEffect(() => {
        setTimeout(
            () => setIsLoading(false),
            0);
    }, []);

    const isLoadingMemorized = useMemo(() => isLoading, [isLoading]);

    return {
        isLoading: isLoadingMemorized,
    };
}