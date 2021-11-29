import { createContext, ReactNode, useContext, useEffect, useMemo, useState } from 'react';
import { PomodoroStore } from '../../../../stores/pomodoroStore';

export interface PomodoroStoreService {
    store: PomodoroStore;
    isLoading: boolean;
}

const pomodoroContext = createContext<PomodoroStoreService | null>(null);

export function usePomodoroStore() {
    const context = useContext(pomodoroContext);
    if (!context)
        throw new Error('usePomodoroStore must be inside PomodoroStoreProvider');

    return context;
}

export function PomodoroStoreProvider({ children }: { children: ReactNode }) {
    const store = useMemo(() => new PomodoroStore(), []);

    const [isLoading, setIsLoading] = useState<boolean>(false);

    useEffect(() => {
        setIsLoading(true);
        store.loadPomodoroList()
            .finally(() => setIsLoading(false));
    }, []);

    return (
        <pomodoroContext.Provider
            value={{ store, isLoading }}
        >
            {children}
        </pomodoroContext.Provider>
    );
}