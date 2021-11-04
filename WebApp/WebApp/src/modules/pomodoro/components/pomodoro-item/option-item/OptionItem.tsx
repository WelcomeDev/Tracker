import { Icon } from "@iconify/react";
import { Action } from "../../../../../components/interfaces/Action";
import { ClassName } from "../../../../../components/interfaces/ClassName";

export interface OptionItemProps extends ClassName {
    title: string;
    iconPath: string;

    onClick: Action;
}

export function OptionItem(props: OptionItemProps) {

    const { title, iconPath, onClick, className } = props;

    return (
        <div
            title={title}
            className={className}>
            <Icon
                icon={iconPath}
                onClick={onClick}
                style={{ width: "100%", height: "100%" }} />
        </div>

    )
}