export function cancellablePromise<T>(promise: Promise<T>) {
    const isCancelled = { value: false };
    const wrappedPromise = new Promise<T>((resolve, reject) => {
        promise
            .then(res => {
                console.log(`is cancellation requested? ${isCancelled.value}`)
                console.log(isCancelled)
                const onReturn = isCancelled.value ? reject(isCancelled) : resolve(res)
                console.log(onReturn);
                return onReturn;
            })
            .catch(e => reject(isCancelled.value ? isCancelled : e));
    });

    return {
        promise: wrappedPromise,
        cancel: () => {
            isCancelled.value = true;
        },
    }
}
