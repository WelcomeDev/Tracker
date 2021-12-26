import { Token } from '../model/token';

export class TokenStorage {
    private static TOKEN_KEY = 'Tracker_Jwt';

    public static getToken(): Token | null {
        const storedItem = localStorage.getItem(this.TOKEN_KEY);
        if (!storedItem) return null;

        return JSON.parse(storedItem) as Token;
    }

    public static saveToken(token: Token) {
        localStorage.setItem(this.TOKEN_KEY, JSON.stringify(token));
    }
}