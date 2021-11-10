import { useLocation, useNavigate } from "react-router-dom";
import './headerItem.scss';

export interface HeaderItemProps {
    title: string;
    url: string;
}

export function HeaderItem(props: HeaderItemProps) {
    const { url: curUrl } = props;

    const location = useLocation();
    const navigate = useNavigate()
    return (
        <p className={'header-item'}
            onClick={() => {
            navigate(curUrl);
            console.log(`On navigate ${location.pathname} to ${curUrl}`)
        }
        }
           style={{ fontWeight: location.pathname === curUrl ? "bold" : "normal" }}>
            {props.title}
        </p>
    )
}
