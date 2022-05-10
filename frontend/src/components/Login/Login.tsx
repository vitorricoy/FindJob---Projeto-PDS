import React from "react";
import {} from '@material-ui/core';
import { 
    Container, 
    LeftContainer, 
    RightContainer,
    StyledTitle,
    StyledWelcomeMessage,
    StyledEmailInput,
    StyledPasswordInput,
    StyledLoginButton,
    StyledSignUp,
    OuterContainer,
    StyledInputDiv,
} from "./styles";

export function Login() {
    return (
        <Container>
            <LeftContainer>
                <img draggable="false" src="https://i.imgur.com/GIwPUzY.jpeg" alt="Workhome Login" width='100%' height='100%'/>
            </LeftContainer>

            <RightContainer>
                <OuterContainer>
                    <StyledTitle>
                        <div className="title">FindJob</div>
                        <div className="subTitle">Plataforma de freelance</div>
                    </StyledTitle>

                    <StyledWelcomeMessage>
                        <div className="l1">Bem vindo</div>
                        <div className="l2">Entre na sua conta</div>
                    </StyledWelcomeMessage>

                    <StyledInputDiv>
                        <StyledEmailInput id="outlined-email" label="E-mail" variant="outlined" />
                    </StyledInputDiv>

                    <StyledInputDiv>
                        <StyledPasswordInput id="outlined-password" label="Senha" variant="outlined" type="password"/>
                    </StyledInputDiv>

                    <StyledInputDiv>
                        <StyledLoginButton variant="contained"> Entrar </StyledLoginButton>
                    </StyledInputDiv>

                    <StyledSignUp>
                        <div>Não possui uma conta?</div><a style={{textDecoration: "none", color: "#2B6CB0"}} className="signUpButton" href="">Crie uma gratuitamente.</a>
                    </StyledSignUp>
                </OuterContainer>
            </RightContainer>
        </Container>
    )
}