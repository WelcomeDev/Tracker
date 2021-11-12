import { Action } from "../interfaces/actionTyped";
import './modal.scss';
import classNames from "classnames";
import { ReactNode } from "react";

export interface SettingsModalProps {
    isActive: boolean;
    setActive: Action<boolean>;
    children: ReactNode;
}

export function Modal({ isActive, children, setActive }: SettingsModalProps) {
    return (
        <div
            className={classNames('modal', isActive ? 'active' : '')}
            onClick={() => setActive(false)}>
            <section className="modal__content"
                     onClick={e => e.stopPropagation()}>
                {children}
            </section>
        </div>
    )
}
