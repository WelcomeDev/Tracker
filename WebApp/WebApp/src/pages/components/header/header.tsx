import { HeaderItem } from "./header-item/headerItem";
import { headersSource } from "./headersSource";
import { FlexContainer } from "../../../components/alignment/flexConteiner";
import { ReactComponent as AppIcon } from './assets/app-icon.svg';
import './header.scss';

export function Header() {
    return (
        <header className={'header'}>
            <div className={'content-container'}>
                <FlexContainer
                    flexDirection={'row'}
                    justifyContent={"space-between"}
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
                    </ul>
                </FlexContainer>
            </div>
        </header>
    )
}
