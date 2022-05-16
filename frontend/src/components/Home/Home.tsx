import React from "react";
import { 
    Body,
    Buttons,
    Container,
    StyledButton,
} from "./styles";
import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";

export function Home () {
    const [freelancer, setFreelancer] = React.useState(false);
    
    return (
        <Container>

            <Header/>

            <Body>
                <img draggable="false" src="https://i.imgur.com/auZepyp.jpg" alt="Workhome Login" width='100%' height='100%'/>
                <div className="up-bottom-right">Encontre</div>
                {freelancer? 
                    <div className="bottom-right">Trabalhos para colocar em prática suas habilidades</div>
                    :
                    <div className="bottom-right">Profissionais qualificados para qualquer tarefa</div>}
            </Body>

            <Buttons>
                <div style={{alignSelf: "center"}}>
                    <StyledButton variant="contained"> {freelancer? "Buscar jobs": "Novo job"} </StyledButton>
                </div>
                
                <div style={{alignSelf: "center"}}>
                    <StyledButton variant="contained"> Meus jobs </StyledButton>
                </div>
            </Buttons>

            <Footer/>
        </Container>
    );
}