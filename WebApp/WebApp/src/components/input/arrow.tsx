import { Action } from "../interfaces/action";

export enum ArrowDirection {
    TOP,
    RIGHT,
    BOTTOM,
    LEFT
}

export interface ArrowProps {
    thickness: number;

    direction?: ArrowDirection;
    cornerRadius?: number;
    onClick?: Action;
    className?: string;
}

export function Arrow(props: ArrowProps) {
    const rotAmount = !props.direction ? 0 : props.direction as number;
    return (
        <div
            onClick={props.onClick}
            style={{
                borderRadius: `${props.cornerRadius}px 0px 0px 0px`,
                borderWidth: `${props.thickness}px 0 0 ${props.thickness}px`,
                borderStyle: 'solid solid solid solid',
                transform: `rotate(${rotAmount * 90 + 45}deg)`,
                backgroundColor: 'transparent',
            }}
            className={props.className}>
        </div>
    )
}
