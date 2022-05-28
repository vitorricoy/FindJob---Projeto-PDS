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
    height: 60vh;

    .bottom-right {
        position: absolute;
        bottom: 38vh;
        right: 10vh;

        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 600;
        font-size: 2.8vh;
        line-height: 3vh;
        color: #FFFFFF;

        text-shadow: 2px 2px #000000;
        max-width: 280px;
    }

    .up-bottom-right {
        position: absolute;
        bottom: 50vh;
        right: 20vh;

        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 7vh;
        line-height: 7.5vh;
        color: #FFFFFF;

        text-shadow: 3px 3px #000000;
    }
`;

export const Buttons = styled.div`
    height: 27.5vh;
    display: flex;
    justify-content: space-between;
    margin-inline: 12%;
`;

export const StyledButton = styled(Button)`
    margin: auto;
    width: 50vh;
    height: 7vh;
    background-color: #004E85 !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 4vh;
        line-height: 4.7vh;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

