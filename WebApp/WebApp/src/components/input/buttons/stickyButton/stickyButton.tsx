import './stickyButton.scss';
import { Action } from '../../../interfaces/action';
import { Icon } from '@iconify/react';
import classNames from 'classnames';

export interface StickyButtonProps {
    onClick?: Action;
    icon: string;
    className?: string;
}

export function StickyButton(props: StickyButtonProps) {
    return (
        <div
            className={classNames('sticky-button-container', props.className)}
            onClick={props.onClick}
        >
            <Icon
                className={'sticky-button-container__icon'}
                icon={props.icon}
            />
        </div>
    );
}