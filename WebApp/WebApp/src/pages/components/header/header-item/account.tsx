import './account.scss';
import { Icon } from '@iconify/react';

export interface AccountProps {
    username: string;
}

export function Account(props:AccountProps) {
    return (
        <div
            className={'account-header-item'}
            onClick={()=>alert('This is displayed only for admin')}
        >
            <Icon
                className={'account-header-item__icon'}
                icon={'mdi:account'}
            />
            <p>{props.username}</p>
        </div>
    );
}
