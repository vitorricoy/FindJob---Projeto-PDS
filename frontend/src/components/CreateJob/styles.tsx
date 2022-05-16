import { Button, TextField } from "@material-ui/core";
import styled from "styled-components";
import MuiList from '@mui/material/List';

export const Container = styled.div`
    height: 100vh;
    width: 100vw;
    position: relative;
    max-height: 100vh;
    justify-content: space-between;
`;

export const Body = styled.div`
    height: 87.5vh;
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
    height: 35%;
    padding-block: 3vh 0.5vh;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 8vh;
    line-height: 8.2vh;

    color: #000000;
`;

export const DescribeYourJobBottom = styled.div`
    margin: auto;
    width: 90%;
    height: 50%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 4vh;
    line-height: 4.2vh;

    color: #000000;
`;

export const TitleDescription1 = styled.div`
    padding-top: 1.5%;
    padding-bottom: 1.5%;
    height: 10%;
    width: 90%;
    margin: auto;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 6vh;
    line-height: 6.2vh;
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
    font-size: 6vh;
    line-height: 6.2vh;
    color: #000000;
`;

export const TitleDescription4 = styled.div`
    height: 45%;
    width: 90%;
    margin: auto;
    padding-top: 1.5%;
    overflow-y: auto;

`;

export const TitleDescription5 = styled.div`
    height: 15%;
    width: 90%;
    margin: auto;
    padding-top: 1%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 6vh;
    line-height: 6.2vh;
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

    & .MuiOutlinedInput-inputMarginDense {
        padding-top: 1vh;
        padding-bottom: 1vh;
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

    & .MuiOutlinedInput-multiline {
        padding: 1vh 1.5vh;
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

    & .MuiOutlinedInput-inputMarginDense {
        padding-top: 1.5vh;
        padding-bottom: 1.5vh;
        font-size: 3vh;
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
    font-size: 6vh;
    line-height: 6.2vh;
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

    overflow-y: auto;
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

    & .MuiOutlinedInput-inputMarginDense {
        padding-top: 1vh;
        padding-bottom: 1vh;
    }

    & .MuiFormControl-root {
        width: 10vh;
    }

`;

export const StyledAddSkillButton = styled(Button)`
    background-color: #004E85 !important;
    height: 2.5vh !important;
    min-width: 2.5vh !important;
    max-width: 2.5vh !important;
    padding: 1.8vh 1.8vh !important;

    .MuiButton-label {
        color: #FFFFFF;
        font-size: x-large;
    }
`;

export const StyledButton = styled(Button)`
    margin: auto;
    width: 80%;
    height: 80px;
    background-color: #04C35C !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 4.5vh;
        line-height: 4.7vh;
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
    font-size: 3.5vh;
    line-height: 3.7vh;
    color: #000000;
`;

export const Payment2 = styled.div`
    height: 20%;
    width: 90%;
    margin: auto;
`;

export const Payment3 = styled.div`
    height: 10%;
    width: 90%;
    margin: auto;
    padding-top: 4%;
`;

export const Payment4 = styled.div`
    height: 20%;
    width: 90%;
    margin: auto;
    text-align-last: center;
    padding-top: 11%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 6vh;
    line-height: 6vh;
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

    & .MuiOutlinedInput-input {
        padding: 1.3vh 1.5vh;
        font-size: 3vh;
    }
`;

export const StyledList = styled(MuiList)`
    & .MuiListItem-root {
        padding-top: 0 !important;
        padding-bottom: 0 !important;
    }

    padding-top: 0 !important;
`;