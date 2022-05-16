import { StyledFooter } from "./styles"

export function Footer () {
    return (
        <StyledFooter>
            <div style={{paddingBlock: "0.8vh 0.2vh"}}>Belo Horizonte. {new Date(Date.now()).toString()}</div>
            <div> © 2022 FindJob. Todos os direitos reservados. </div>
        </StyledFooter>
    )
}
