import { useLocation, useNavigate } from "react-router-dom";

export interface HeaderItemProps {
    title: string;
    url: string;
}

export function HeaderItem(props: HeaderItemProps) {
    const location = useLocation();
    return (
        <div>

        </div>
    )
}
