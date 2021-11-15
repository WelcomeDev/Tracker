import { Action } from "../interfaces/action";
import './iconButton.scss';
import classNames from "classnames";
import { Icon } from "@iconify/react";

export interface IconButtonProps {
    src: string;
    title?: string;
    onClick?: Action;
    className?: string;
}

export function IconButton({ src, ...other }: IconButtonProps) {
    return (
        <button
            className={classNames('icon-button', other.className)}
            onClick={other.onClick}
            title={other.title}>
            <Icon
                icon={src}
                className={'icon-button__icon'}/>
        </button>
    )
}
