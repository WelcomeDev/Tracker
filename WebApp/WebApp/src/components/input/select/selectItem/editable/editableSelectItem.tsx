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
    name: string;
    id: string;
    className?: string;
    onSelectCallback?: Action<{name:string, id:string}>;
}

export function EditableSelectItem(props: SelectItemProps) {

    const { id, name } = props;

    return (
        <div
            className={'editable-select-item'}
            onClick={()=>props.onSelectCallback && props.onSelectCallback({name, id})}
        >
            <p
                className={'editable-select-item__text'}
            >
                {name}
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