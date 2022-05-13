import styled from "styled-components"

import {
    MainContainer,
    ChatContainer,
    MessageList
} from "@chatscope/chat-ui-kit-react";
let styles = require('@chatscope/chat-ui-kit-styles/dist/default/styles.min.css');
let customStyle = require('./custom-style.css');

export const Container = styled(MainContainer)`
    height: 88vh !important;
`


export const ChatContainerStyled = styled(ChatContainer)`
    ${customStyle}
`

export const ChatStyle = styled.div`
    ${styles}
`

export const MessagesTextTitle = styled.div`
    float:left;
    width: 176px;
    height: 32px;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
    line-height: 158.5%;

    letter-spacing: 0.1em;
    text-transform: uppercase;

    color: #0F82FF;
    text-align: center;
`