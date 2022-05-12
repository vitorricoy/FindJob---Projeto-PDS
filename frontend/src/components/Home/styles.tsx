import { Button } from "@material-ui/core";
import styled from "styled-components";

export const Container = styled.div`
    height: 100vh;
    width: 100vw;
    position: relative;
    max-height: 100vh;
    justify-content: space-between;
`;

export const Body = styled.div`
    height: 60%;

    .bottom-left {
        position: absolute;
        bottom: 370px;
        right: 150px;

        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 600;
        font-size: 30px;
        line-height: 35px;
        color: #FFFFFF;

        text-shadow: 2px 2px #000000;
        max-width: 280px;
    }

    .up-bottom-left {
        position: absolute;
        bottom: 500px;
        right: 82px;

        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 60px;
        line-height: 65px;
        color: #FFFFFF;

        text-shadow: 3px 3px #000000;
    }
`;

export const Buttons = styled.div`
    height: 25%;
    display: flex;
    justify-content: space-between;
    margin-inline: 12%;
`;

export const StyledButton = styled(Button)`
    margin: auto;
    width: 420px;
    height: 80px;
    background-color: #004E85 !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 40px;
        line-height: 47px;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

