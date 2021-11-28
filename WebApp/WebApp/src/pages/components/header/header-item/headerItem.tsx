import { useLocation, useNavigate } from "react-router-dom";
import './headerItem.scss';
import classNames from "classnames";

export interface HeaderItemProps {
    title: string;
    url: string;
}

export function HeaderItem(props: HeaderItemProps) {
    const { url: curUrl } = props;

    const location = useLocation();
    const navigate = useNavigate()
    return (
        <li
            className={classNames('header-item', location.pathname === curUrl && 'selected')}
            onClick={() => {
                navigate(curUrl);
            }}
        >
            {props.title}
        </li>
    )
}
