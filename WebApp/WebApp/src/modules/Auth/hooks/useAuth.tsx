import { createContext, ReactNode, useContext, useEffect, useMemo, useState } from 'react';
import { login, whoAmI } from '../actions/authActions';
import { User } from '../model/user';

export interface AuthService {
    isLoading: boolean;
    login: (username: string, password: string) => Promise<void>;
    user: User | null;
}

const authContext = createContext<AuthService | null>(null);

export function useAuth() {
    const context = useContext(authContext);
    if (!context) throw new Error('useAuth must be inside AuthProvider');

    return context;
}

export function AuthProvider({ children }: { children: ReactNode }) {
    const [isLoading, setIsLoading] = useState(false);
    const [user, setUser] = useState<User | null>(null);

    useEffect(() => {
        setIsLoading(true);
        whoAmI()
            .then(apiUser => setUser(apiUser))
            .finally(() => setIsLoading(false));
    }, []);

    function onLogin(username: string, password: string) {
        setIsLoading(true);
        return login({ username, password })
            .then(whoAmI)
            .then(apiUser => setUser(apiUser))
            .finally(() => setIsLoading(false));
    }

    const isLoadingMemorized = useMemo(() => ({
            isLoading,
            login: onLogin,
            user,
        }
    ), [user, isLoading]);

    return (
        <authContext.Provider value={isLoadingMemorized}>
            {children}
        </authContext.Provider>
    );
}
