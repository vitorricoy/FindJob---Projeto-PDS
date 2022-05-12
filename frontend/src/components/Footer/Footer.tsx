import { StyledFooter } from "./styles"

export function Footer () {
    return (
        <StyledFooter>
            <div style={{paddingBlock: "6px 4px"}}>Belo Horizonte. {new Date(Date.now()).toString()}</div>
            <div> © 2022 FindJob. Todos os direitos reservados. </div>
        </StyledFooter>
    )
}