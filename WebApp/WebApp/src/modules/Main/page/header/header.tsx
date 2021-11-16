import { HeaderItem } from "./header-item/headerItem";
import { headersSource } from "./headersSource";
import { FlexContainer } from "../../../../components/alignment/flexConteiner";

export interface HeaderProps {
    className?: string;
}

export function Header(props: HeaderProps) {
    return (
        <header className={props.className}>
            <div className={'content-container'}>
                <FlexContainer flexDirection={"row"}>
                    {headersSource.map(item => (<HeaderItem
                        url={item.url}
                        title={item.title}/>))}
                </FlexContainer>
            </div>
        </header>
    )
}
