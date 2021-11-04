import { type } from "os";
import { ReactNode } from "react";
import { ClassName } from "../interfaces/ClassName";

type FlexDirection = "row" | "column";
type JustifyContent = "flex-start" | "fles-end" | "space-between" | "space-around";

export interface FlexContainerProps extends ClassName {
    flexDirection?: FlexDirection;
    justifyContent?: JustifyContent;

    children: ReactNode;
}

export function FlexContainer(props: FlexContainerProps) {
    return (
        <div style={{
            display: "flex",
            flexDirection: props.flexDirection,
            justifyContent: props.justifyContent,
        }}>
            {props.children}
        </div>
    )
}