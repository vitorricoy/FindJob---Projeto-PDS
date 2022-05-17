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

export function Home () {
    const [freelancer, setFreelancer] = React.useState(true);

    let navigate = useNavigate();

    const handleFirstButtonClick = (event: any) => {
        return (freelancer?  navigate("/jobs-list/find-jobs"): navigate("/create-job"));
    }

    const handleSecondButtonClick = (event: any) => {
        return navigate("/jobs-list/my-jobs");
    }
    
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
                    <StyledButton variant="contained" onClick={handleFirstButtonClick}> {freelancer? "Buscar jobs": "Novo job"} </StyledButton>
                </div>
                
                <div style={{alignSelf: "center"}}>
                    <StyledButton variant="contained" onClick={handleSecondButtonClick}> Meus jobs </StyledButton>
                </div>
            </Buttons>

            <Footer/>
        </Container>
    );
}