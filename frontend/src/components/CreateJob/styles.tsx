import { Button, ListItem, TextField } from "@material-ui/core";
import styled from "styled-components";

export const Container = styled.div`
    height: 100vh;
    width: 100vw;
    position: relative;
    max-height: 100vh;
    justify-content: space-between;
`;

export const Body = styled.div`
    height: 85%;
    display: flex;
`;

export const LeftDiv = styled.div`
    width: 70%;
`;

export const RightDiv = styled.div`
    width: 30%;
`;

export const DescribeYourJobDiv = styled.div`
    height: 30%;
    position: relative;
`;

export const TitleDescriptionDiv = styled.div`
    height: 70%
`;

export const GrayPaper = styled.div`
    width: 90%;
    height: 90%;
    border-radius: 15px;
    background-color: #E6E6E6;

    position: relative;
    top: 50%;
    -webkit-transform: translateY(-50%);
    -ms-transform: translateY(-50%);
    transform: translateY(-50%);
    margin: auto;
`;

export const SkillsDiv = styled.div`
    height: 40%;
`;

export const PaymentDiv = styled.div`
    height: 40%;
`;

export const PostJobDiv = styled.div`
    height: 20%;
`;

export const DescribeYourJobUp = styled.div`
    margin: auto;
    width: 90%;
    height: 50%;
    padding-block: 4px;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 50px;
    line-height: 59px;

    color: #000000;
`;

export const DescribeYourJobBottom = styled.div`
    margin: auto;
    width: 90%;
    height: 50%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 27px;
    line-height: 32px;

    color: #000000;
`;

export const TitleDescription1 = styled.div`
    padding-top: 2.5%;
    height: 10%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 35px;
    line-height: 41px;
    color: #000000;
`;

export const TitleDescription2 = styled.div`
    height: 10%;
    width: 90%;
    margin: auto;

`;

export const TitleDescription3 = styled.div`
    height: 10%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 35px;
    line-height: 41px;
    color: #000000;
`;

export const TitleDescription4 = styled.div`
    height: 50%;
    width: 90%;
    margin: auto;

`;

export const TitleDescription5 = styled.div`
    height: 15%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 35px;
    line-height: 41px;
    color: #000000;
`;

export const TitleTextField = styled(TextField)`
    width: 100%;
    background-color: white;

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }
`;

export const DescriptionTextField = styled(TextField)`
    width: 100%;
    background-color: white;

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }
`;

export const DateTextField = styled(TextField)`
    width: 8%;
    background-color: white;

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }
`;

export const Skills1 = styled.div`
    height: 22.5%;
    padding-top: 2%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 35px;
    line-height: 41px;
    color: #000000;
`;

export const Skills2 = styled.div`
    height: 17%;
    width: 90%;
    margin: auto;
`;

export const Skills3 = styled.div`
    height: 50%;
    width: 90%;
    margin: auto;

    overflow-y: scroll;
`;

export const SkillField = styled(TextField)`
    width: 87.8%;
    background-color: white;

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }
`;

export const StyledAddSkillButton = styled(Button)`
    background-color: #004E85 !important;
    height: 28px !important;
    min-width: 28px !important;
    max-width: 28px !important;
    padding: 18px 18px !important;

    .MuiButton-label {
        color: #FFFFFF;
        font-size: x-large;
    }
`;

export const StyledButton = styled(Button)`
    margin: auto;
    width: 80%;
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

export const Payment1 = styled.div`
    padding-top: 2.5%;
    height: 20%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 30px;
    line-height: 35px;
    color: #000000;
`;

export const Payment2 = styled.div`
    height: 20%;
    width: 90%;
    margin: auto;
`;

export const Payment3 = styled.div`
    height: 20%;
    width: 90%;
    margin: auto;
`;

export const Payment4 = styled.div`
    height: 35%;
    width: 90%;
    margin: auto;
    text-align-last: center;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 55px;
    line-height: 64px;
    color: #000000;
`;

export const CurrencyTextField = styled(TextField)`
    width: 20%;
    background-color: white;

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }
`;