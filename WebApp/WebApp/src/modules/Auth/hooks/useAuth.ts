import { useEffect, useMemo, useState } from 'react';
import { login, whoAmI } from '../actions/authActions';
import { User } from '../model/user';

export function useAuth() {
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

    return {
        ...isLoadingMemorized,
    };
}