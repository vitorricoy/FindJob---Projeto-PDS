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
`;

export const RightDiv = styled.div`
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
    overflow: hidden;
`;

export const FindJobsUp = styled.div`
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

export const FindJobsBottom = styled.div`
    margin: auto;
    width: 90%;
    height: 50%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 2.7vh;
    line-height: 2.9vh;

    color: #000000;
`;

export const Filters1 = styled.div`
    margin: auto;
    width: 90%;
    height: 10%;
    padding-top: 2%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 5vh;
    line-height: 6vh;

    color: #000000;
`;

export const Filters2 = styled.div`
    margin: auto;
    width: 90%;
    height: 10%;
`;

export const Filters3 = styled.div`
    margin: auto;
    width: 90%;
    height: 12%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 2vh;
    line-height: 3vh;

    color: #000000;
`;

export const Filters4 = styled.div`
    margin: auto;
    width: 90%;
    height: 15%;
    margin-block: 1%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 2vh;
    line-height: 3vh;

    color: #000000;
`;

export const Filters5 = styled.div`
    margin: auto;
    width: 90%;
    height: 5%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 3.8vh;
    line-height: 4vh;

    color: #000000;
`;

export const Filters6 = styled.div`
    margin: auto;
    width: 90%;
    height: 7%;
    margin-top: 2%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 2.8vh;
    line-height: 3vh;

    color: #000000;
`;

export const Filters7 = styled.div`
    height: 35%;
`;

export const CurrencyTextField = styled(TextField)`
    width: 20%;
    background-color: ${props => props.disabled? "#E6E6E6": "#FFFFFF"};

    & .MuiOutlinedInput-root {
        & fieldset {
            border-width: 2px;
        },
        &:hover fieldset {
            border-width: 2px;
        }
    }

    & .MuiOutlinedInput-input {
        height: 8px;
    }

    & .MuiOutlinedInput-inputMarginDense {
        padding-top: 1vh;
        padding-bottom: 1vh;
    }

    & .MuiOutlinedInput-input {
        padding: 1vh 1vh;
    }
`;

export const Skills1 = styled.div`
    height: 22.5%;
    padding-top: 2%;
    width: 90%;
    margin: auto;
    padding-bottom: 1%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 3.8vh;
    line-height: 4vh;
    color: #000000;
`;

export const Skills2 = styled.div`
    padding-bottom: 2%;
    width: 90%;
    margin-inline: 5% 0;
    display: flex;
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

export const JobsList1 = styled.div`
    padding-top: 2.2%;
    height: 12%;
    text-align: center;
`;

export const JobsList2 = styled.div`
    height: 85%;
    overflow-y: scroll;
`;

export const SearchJobTextField = styled(TextField)`
    width: 90%;
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

export const ListItemDiv = styled.div`
    background-color: white;
    height: 108px !important;
    width: 90%;
    margin: auto;
    border-radius: 10px;
`;

export const SkillsDiv = styled.div`
    margin-block: 0.7%;
    margin-inline: 6%;
    display: flex;
    flex-flow: wrap;
`;

export const StyledList = styled(MuiList)`
    & .MuiListItem-root {
        padding-top: 0 !important;
        padding-bottom: 0 !important;
    }

    padding-top: 0 !important;

    & .MuiIconButton-root {
        padding: 1vh !important; 
    }
`;
