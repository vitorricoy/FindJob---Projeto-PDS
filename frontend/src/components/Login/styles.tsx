import { Button, TextField } from "@material-ui/core";
import styled from "styled-components";

export const Container = styled.div`
    display: flex;
    height: 99.5vh;
    width: 99.5vw;
`;

export const LeftContainer = styled.div`
    width: 50%;
`;

export const RightContainer = styled.div`
    width: 50%;
`;

export const StyledTitle = styled.div`
    padding-top: 12vh;

    .title {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 48px;
        line-height: 56px;
    }

    .subTitle {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 32px;
        line-height: 38px;
    }
`;

export const OuterContainer = styled.div`
    user-select: none;
    height: 100vh;
    width: 386px;
    margin: 0 auto;
`;

export const StyledWelcomeMessage = styled.div`
    margin-top: 10vh;

    .l1 {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 400;
        font-size: 16px;
        line-height: 19px;
        color: #2D3748;
    }

    .l2 {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 30px;
        line-height: 35px;
        color: #1A202C;
    }
`;

export const StyledEmailInput = styled(TextField)`
    width: 386px;
    margin-block: 8px;
`;

export const StyledPasswordInput = styled(TextField)`
    width: 386px;
    margin-block: 8px;
`;

export const StyledLoginButton = styled(Button)`
    margin-block: 32px;
    width: 386px;

    background-color: #04C45C !important;
    height: 50px !important;

    .MuiButton-label {
        color: #FFFFFF;
    }
`;

export const StyledSignUp = styled.div`
    padding-bottom: 6vh;
    display: flex;
    position: absolute;
    bottom: 0;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 16px;
    line-height: 19px;
    color: #616161;

    .signUpButton {
        margin-left: 4px;
    }
`;

export const StyledInputDiv = styled.div`
    margin-block: 24px;
`;