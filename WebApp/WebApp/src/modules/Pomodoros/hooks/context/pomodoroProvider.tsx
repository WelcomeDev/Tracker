import { createContext, ReactNode, useContext, useEffect, useMemo } from 'react';
import { PomodoroStore } from '../../../../stores/pomodoroStore';

export const pomodoroContext = createContext<PomodoroStore | null>({} as PomodoroStore);
pomodoroContext.displayName  = 'PomodoroStoreContext';

export function usePomodoroStore(): PomodoroStore {
    const context = useContext(pomodoroContext);
    if (!context)
        throw new Error('usePomodoroStore must be inside PomodoroStoreProvider');

    return context;
}

export function PomodoroStoreProvider({ children }: { children: ReactNode }) {
    const store = useMemo(() => new PomodoroStore(), []);

    useEffect(() => {
        store.loadPomodoroList();
    }, []);

    return (
        <pomodoroContext.Provider
            value={store}
        >
            {children}
        </pomodoroContext.Provider>
    );
}