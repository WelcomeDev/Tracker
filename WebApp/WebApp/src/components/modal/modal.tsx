import { CSSProperties, ReactNode } from "react";
import { Action } from "../interfaces/action";

export interface SettingsModalProps {
    onClose: Action;
    children: ReactNode;

    menuClassName?: string;
    contentClassName?: string;
    menuStyle?: CSSProperties;
    contentStyle?: CSSProperties;
}

export function Modal({ children, onClose, ...optionalProps }: SettingsModalProps) {
    return (
        <div
            style={optionalProps.menuStyle}
            className={optionalProps.menuClassName}
            onClick={() => onClose()}
        >
            <section
                onClick={e => e.stopPropagation()}
                className={optionalProps.contentClassName}
                style={optionalProps.contentStyle}
            >
                {children}
            </section>
        </div>
    )
}
