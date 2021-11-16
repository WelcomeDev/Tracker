import { HeaderItem } from "./header-item/headerItem";
import { headersSource } from "./headersSource";
import { FlexContainer } from "../../../../components/alignment/flexConteiner";
import { ReactComponent as AppIcon } from './assets/app-icon.svg';
import './header.scss';

export interface HeaderProps {
    className?: string;
}

export function Header(props: HeaderProps) {
    return (
        <header className={props.className}>
            <div className={'content-container'}>
                <FlexContainer
                    flexDirection={'row'}
                    justifyContent={"space-between"}
                    className={'header-outer-container'}
                    alignItems={'center'}
                >
                    <AppIcon className={'app-icon'}/>
                    <FlexContainer
                        flexDirection={"row"}
                        justifyContent={"space-around"}
                        className={'navigation-items'}
                    >
                        {headersSource.map(item => (<HeaderItem
                            key={item.url}
                            url={item.url}
                            title={item.title}/>))}
                    </FlexContainer>
                </FlexContainer>
            </div>
        </header>
    )
}
