import { HeaderItem } from "./header-item/headerItem";
import { headersSource } from "./headersSource";
import './header.scss';
import { FlexContainer } from "../../../../components/alignment/flexConteiner";

export function Header() {
    return (
        <header className={'header'}>
           <FlexContainer flexDirection={"row"}>
               {headersSource.map(item => (<HeaderItem
                   url={item.url}
                   title={item.title}/>))}
           </FlexContainer>
        </header>
    )
}
