import { UseFormHookInputProps } from '../../../components/interfaces/props/useFormHookInputProps';

export interface UsernameProps extends UseFormHookInputProps {
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