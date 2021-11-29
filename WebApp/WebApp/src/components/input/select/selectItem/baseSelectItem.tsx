import './baseSelectItem.scss';
import { JSXElementConstructor } from 'react';

export interface BaseSelectItemProps<PropsType> {
    SelectItem: JSXElementConstructor<PropsType>;
    props: PropsType;
}

export function BaseSelectItem<PropsType>({ SelectItem, props }: BaseSelectItemProps<PropsType>) {
    return (
        <div className={'base-select-item'}>
            <SelectItem
                {...props}
            />
        </div>
    );
}