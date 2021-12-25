export interface Action<T> {
    (arg: T): void;
}
