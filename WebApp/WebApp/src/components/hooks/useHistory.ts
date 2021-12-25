import { useLocation, useNavigate } from 'react-router-dom';

export function useHistory() {
    const location = useLocation();
    const navigate = useNavigate();

    return {
        location,
        navigate,
    };
}