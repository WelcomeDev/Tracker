import { Action } from '../../../../interfaces/actionTyped';
import { Icon } from '@iconify/react';

import './editableSelectItem.scss';
import { IconButton } from '../../../buttons/iconButton/iconButton';

export interface SelectItemProps /*extends UseFormHookInputProps*/
{
    /**
     * Calls on edit by id
     */
    onEditCallback?: Action<string>;
    title: string;
    id: string;
    className?: string;
}

export function EditableSelectItem(props: SelectItemProps) {

    const { id } = props;

    return (
        <div
            className={'editable-select-item'}
        >
            <p
                className={'editable-select-item__text'}
            >
                {props.title}
            </p>
            {
                // props.onEditCallback &&
                <IconButton
                    src={'mdi:lead-pencil'}
                    className={'editable-select-item__edit-button'}
                    onClick={() => props.onEditCallback && props.onEditCallback(id)}
                />
            }
        </div>
    );
}