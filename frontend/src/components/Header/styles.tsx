import { Button, ListItem } from "@material-ui/core";
import styled from "styled-components";

export const StyledHeader = styled.div`
    height: 7.5vh;
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
    font-size: 30px;
    line-height: 5vh;
    color: #FFFFFF;
`;

export const SubTitle = styled.div`
    margin-inline: 94px 0;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 15px;
    line-height: 1vh;
    color: #FFFFFF;
`;

export const NotificationIcon = styled.div`
    width: 10%;
    place-self: center;
    text-align: -webkit-center;
`;

export const StyledMenuButton = styled(Button)`
    padding: 0 !important;
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