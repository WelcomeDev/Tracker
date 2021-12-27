import { Icon } from '@iconify/react';
import { ReactNode, useState } from 'react';
import classNames from 'classnames';
import './select.scss';

export interface SelectProps {
    className?: string;
    children?: ReactNode;
    selection: string;
}

export function Select(props: SelectProps) {

    const [isCollapsed, setIsCollapsed] = useState<boolean>(true);

    return (
        <>
            <div
                className={classNames('select-wrapper', props.className)}
            >
                <section
                    onClick={(e) => {
                        setIsCollapsed(!isCollapsed);
                        e.stopPropagation();
                    }}
                    className={'select'}
                >
                    <p>{props.selection}</p>
                    <Icon
                        className={'select__toggle-collapse'}
                        icon={isCollapsed ? 'mdi:chevron-down' : 'mdi:chevron-up'}
                    />
                </section>
                <div
                    className={classNames('select-popup', !isCollapsed && 'select-popup__display')}
                >
                    {
                        !isCollapsed &&
                        <>
                            <ul className={'items-list'}>
                                {props.children}
                            </ul>
                            <button
                                className={'create-button'}>
                                Add
                            </button>
                        </>
                    }
                </div>
            </div>
        </>
    );
}