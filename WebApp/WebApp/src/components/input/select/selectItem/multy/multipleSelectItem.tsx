import classNames from 'classnames';
import './multipleSelectItem.scss';

export interface MultipleSelectProps /*extends UseFormHookInputProps*/
{
    name: string;
    id: string;
    className?: string;
}

export function MultipleSelectItem(props: MultipleSelectProps) {
    const { id } = props;

    return (
        <div
            className={classNames('multiple-select-item', props.className)}
        >
            <input
                id={id}
                type="checkbox"
                className={'multiple-select-item__input'}
            />
            <label
                htmlFor={id}
                className={'multiple-select-item__label'}
            >
                {props.name}
            </label>
        </div>
    );
}