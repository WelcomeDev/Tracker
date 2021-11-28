import { UseFormHookInput } from '../../../components/interfaces/props/useFormHookInput';

export interface UsernameProps extends UseFormHookInput {
    className?: string;
}

export function Username(props: UsernameProps) {
    const { placeholder, className, register } = props;

    return (
        <input
            placeholder={placeholder}
            type={'text'}
            className={className}
            {...register}
        />
    );
}