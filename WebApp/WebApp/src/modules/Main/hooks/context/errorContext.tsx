import { createContext, ReactNode, useContext, useState } from 'react';
import { Action } from '../../../../components/interfaces/actionTyped';

export interface ErrorProvider {
    error: string | null;
    setError: Action<string | null>;
}

const errorContext = createContext<ErrorProvider | null>(null);

export function useError() {
    const context = useContext(errorContext);

    if (!context)
        throw new Error('You can call "UseError" only inside ErrorProvider');

    return context;
}

export function ErrorProvider({ children }: { children: ReactNode }) {

    const [error, setError] = useState<string | null>(null);

    return (
        <errorContext.Provider
            value={{ error, setError }}
        >
            {children}
        </errorContext.Provider>
    );
}