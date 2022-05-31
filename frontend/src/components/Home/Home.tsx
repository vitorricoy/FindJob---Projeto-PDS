import React from "react";
import {
    Body,
    Buttons,
    Container,
    StyledButton,
} from "./styles";
import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";
import { useNavigate } from "react-router-dom";
import { useGlobalState } from "../..";

export function Home() {
    const [currentUser, setCurrentUser] = useGlobalState('currentUser');

    let navigate = useNavigate();

    const handleFirstButtonClick = (event: any) => {
        return (currentUser.IsFreelancer ? navigate("/jobs-list/false") : navigate("/create-job"));
    }

    const handleSecondButtonClick = (event: any) => {
        return navigate("/jobs-list/true");
    }

    return (
        <Container>

            <Header />

            <Body>
                <img draggable="false" src="https://i.imgur.com/auZepyp.jpg" alt="Workhome Login" width='100%' height='100%' />
                <div className="up-bottom-right">Encontre</div>
                {currentUser.IsFreelancer ?
                    <div className="bottom-right">Trabalhos para colocar em prática suas habilidades</div>
                    :
                    <div className="bottom-right">Profissionais qualificados para qualquer tarefa</div>}
            </Body>

            <Buttons>
                <div style={{ alignSelf: "center" }}>
                    <StyledButton variant="contained" onClick={handleFirstButtonClick}> {currentUser.IsFreelancer ? "Buscar jobs" : "Novo job"} </StyledButton>
                </div>

                <div style={{ alignSelf: "center" }}>
                    <StyledButton variant="contained" onClick={handleSecondButtonClick}> Meus jobs </StyledButton>
                </div>
            </Buttons>

            <Footer />
        </Container>
    );
}