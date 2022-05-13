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
    font-size: 27px;
    line-height: 32px;

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
    font-size: 35px;
    line-height: 41px;

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
    font-size: 24px;
    line-height: 29px;

    color: #000000;
`;

export const Filters4 = styled.div`
    margin: auto;
    width: 90%;
    height: 15%;
    margin-bottom: 5%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 24px;
    line-height: 29px;

    color: #000000;
`;

export const Filters5 = styled.div`
    margin: auto;
    width: 90%;
    height: 5%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 25px;
    line-height: 29px;

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
    font-size: 25px;
    line-height: 29px;

    color: #000000;
`;

export const Filters7 = styled.div`
    margin: auto;
    width: 90%;
    height: 36%;
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
`;

export const Skills1 = styled.div`
    height: 14.5%;
    margin-top: 5%;
    margin-bottom: 1%;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 25px;
    line-height: 29px;
    color: #000000;
`;

export const Skills2 = styled.div`
    height: 17%;
`;

export const Skills3 = styled.div`
    height: 50%;
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