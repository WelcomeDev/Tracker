import { Header } from '../header/header';
import classNames from 'classnames';

export function AppContentPage({ page }: { page: JSX.Element }) {

    return (
        <>
            <Header/>
            <div className={classNames('page-content')}>
                {page}
            </div>
        </>
    );
}