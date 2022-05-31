import React, { useEffect } from "react";
import { } from '@material-ui/core';
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
import { useNavigate } from "react-router-dom";
import { setGlobalState } from "../..";
import axios, { AxiosResponse } from "axios";
import { Constants } from "../../util/Constants";
import User from "../../models/User";

export function Login() {
    const [loggedIn, setLoggedIn] = React.useState(false);

    const [email, setEmail] = React.useState<string>("");
    const [password, setPassword] = React.useState<string>("");

    const [loginError, setLoginError] = React.useState(false);

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    };

    let navigate = useNavigate();

    useEffect(() => {
        if (loggedIn) {
            return navigate("/home");
        }
    }, [loggedIn]);

    const handleLoginButtonClick = async (event: any) => {
        const credentials = {
            "email": email,
            "password": password
        };

        try {
            const user: AxiosResponse<User> = await axios.get(
                Constants.BASE_URL + "api/user/login",
                {
                    params: credentials
                }
            );
            localStorage.setItem("currentUser", JSON.stringify(user.data));
            setGlobalState("currentUser", user.data);

        } catch (error: any) {
            setLoginError(true);
            throw new Error(error);
        }

        setLoggedIn(true);
    }

    return (
        <Container>
            <LeftContainer>
                <img draggable="false" src="https://i.imgur.com/GIwPUzY.jpeg" alt="Workhome Login" width='100%' height='100%' />
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
                        <StyledEmailInput id="login-email" label="E-mail" variant="outlined" value={email} onChange={handleEmailChange} />
                    </StyledInputDiv>

                    <StyledInputDiv>
                        <StyledPasswordInput id="login-password" label="Senha" variant="outlined" type="password" value={password} onChange={handlePasswordChange} />
                    </StyledInputDiv>

                    <div style={{ color: "red", fontSize: "1.8vh" }}>
                        {loginError && "E-mail ou senha inválidos."}
                    </div>

                    <StyledInputDiv>
                        <StyledLoginButton variant="contained" onClick={handleLoginButtonClick}> Entrar </StyledLoginButton>
                    </StyledInputDiv>

                    <StyledSignUp>
                        <div>Não possui uma conta?</div><a style={{ textDecoration: "none", color: "#2B6CB0" }} className="signUpButton" href="./register">Crie uma gratuitamente.</a>
                    </StyledSignUp>
                </OuterContainer>
            </RightContainer>
        </Container>
    )
}
