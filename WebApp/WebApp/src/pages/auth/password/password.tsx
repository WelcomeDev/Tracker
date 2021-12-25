import { Icon } from '@iconify/react';
import { useState } from 'react';
import './password.scss';
import { UseFormHookInputProps } from 'components/interfaces/props/useFormHookInputProps';

export interface PasswordProps extends UseFormHookInputProps {
    className?: string;
}

export function Password(props: PasswordProps) {
    const [showPassword, setShowPassword] = useState<boolean>(false);

    const { register, placeholder, className } = props;

    return (
        <section className={'password-wrapper'}>
            <input
                placeholder={placeholder}
                type={showPassword ? 'text' : 'password'}
                className={className}
                {...register}
            />
            <Icon
                icon={showPassword ? 'mdi:eye' : 'mdi:eye-off'}
                className={'toggle-visibility-icon'}
                onClick={() => setShowPassword(!showPassword)}
            />
        </section>
    );
}