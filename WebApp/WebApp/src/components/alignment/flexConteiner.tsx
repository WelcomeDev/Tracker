import { type } from "os";
import { ReactNode } from "react";
import { ClassName } from "../interfaces/className";

type Base = "flex-start" | "flex-end";
type FlexDirection = "row" | "column";
type JustifyContent = Base | "space-between" | "space-around";
type AlignItems = Base | 'center'

export interface FlexContainerProps extends ClassName {
    flexDirection?: FlexDirection;
    justifyContent?: JustifyContent;
    alignItems?: AlignItems;

    children: ReactNode;
}

export function FlexContainer(props: FlexContainerProps) {
    return (
        <div
            style={{
                display: "flex",
                flexDirection: props.flexDirection,
                justifyContent: props.justifyContent,
                alignItems: props.alignItems,
            }}
            className={props.className}>
            {props.children}
        </div>
    )
}
