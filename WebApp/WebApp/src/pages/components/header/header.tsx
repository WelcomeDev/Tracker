import { HeaderItem } from './header-item/headerItem';
import { headersSource } from './headersSource';
import { FlexContainer } from '../../../components/alignment/flexConteiner';
import { ReactComponent as AppIcon } from './assets/app-icon.svg';
import './header.scss';
import { useAuth } from '../../../modules/Auth/hooks/useAuth';
import { Authorities } from '../../../modules/Auth/model/Authorities';
import { Account } from './header-item/account';

export function Header() {
    const { user } = useAuth();
    return (
        <header className={'header'}>
            <div className={'content-container'}>
                <FlexContainer
                    flexDirection={'row'}
                    justifyContent={'space-between'}
                    className={'header__outer-container'}
                    alignItems={'center'}
                >
                    <AppIcon className={'app-icon'}/>
                    <ul
                        className={'navigation-items'}
                    >
                        {headersSource.map(item => (<HeaderItem
                            key={item.url}
                            url={item.url}
                            title={item.title}/>))}
                        {
                            user?.authority === Authorities.ADMIN &&
                            <Account
                                key={user.id}
                                username={user.name}/>
                        }
                    </ul>
                </FlexContainer>
            </div>
        </header>
    );
}
