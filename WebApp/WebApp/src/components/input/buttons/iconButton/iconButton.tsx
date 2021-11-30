import './iconButton.scss';
import classNames from 'classnames';
import { Icon } from '@iconify/react';
import { Action } from '../../../interfaces/actionTyped';
import React from 'react';

export interface IconButtonProps {
    src: string;
    title?: string;
    onClick?: Action<React.MouseEvent | undefined>;
    className?: string;
    disabled?: boolean;
}

export function IconButton({ src, ...other }: IconButtonProps) {
    return (
        <button
            className={classNames('icon-button', other.className)}
            onClick={(e) => other.onClick && other.onClick(e)}
            title={other.title}
            disabled={other.disabled}>
            <Icon
                icon={src}
                className={'icon-button__icon'}/>
        </button>
    );
}
