import { Button } from "@material-ui/core";
import path from "path";
import styled from "styled-components";

export const Container = styled.div`
    height: 100vh;
    width: 100vw;
    position: relative;
    max-height: 100vh;
    justify-content: space-between;
`;

export const Header = styled.div`
    height: 10%;
    background-color: #406682;
    display: flex;
`;

export const MenuIcon = styled.div`
    width: 10%;
    place-self: center;
    text-align: -webkit-center;
    height: 48px;
`;

export const HeaderTitle = styled.div`
    width: 80%;
`;

export const Title = styled.div`
    margin-block: 4px 0;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 700;
    font-size: 40px;
    line-height: 47px;
    color: #FFFFFF;
`;

export const SubTitle = styled.div`
    margin-inline: 94px 0;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 20px;
    line-height: 23px;
    color: #FFFFFF;
`;

export const NotificationIcon = styled.div`
    width: 10%;
    place-self: center;
    text-align: -webkit-center;
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
export const Footer = styled.div`
    height: 5%;
    background-color: #406682;
    text-align: center;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 12px;
    color: white;
    line-height: 14px;
`;

export const MenuIconSvg = styled.svg`
    display: block;
    pointer-events: none;
    scrollbar-color: rgba(0,0,0,.2) rgba(255,255,255,.1);
    scrollbar-width: thin;
    overflow: hidden;
`;

export const MenuIconSvgPath = styled.path`
    fill: #FFFFFF;
    d: path("M3.314,4.8h13.372c0.41,0,0.743-0.333,0.743-0.743c0-0.41-0.333-0.743-0.743-0.743H3.314
    c-0.41,0-0.743,0.333-0.743,0.743C2.571,4.467,2.904,4.8,3.314,4.8z M16.686,15.2H3.314c-0.41,0-0.743,0.333-0.743,0.743
    s0.333,0.743,0.743,0.743h13.372c0.41,0,0.743-0.333,0.743-0.743S17.096,15.2,16.686,15.2z M16.686,9.257H3.314
    c-0.41,0-0.743,0.333-0.743,0.743s0.333,0.743,0.743,0.743h13.372c0.41,0,0.743-0.333,0.743-0.743S17.096,9.257,16.686,9.257z");
    transform-origin: 0px 0px;
`;

export const StyledMenuButton = styled(Button)`
    padding: 0 !important;
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
`

