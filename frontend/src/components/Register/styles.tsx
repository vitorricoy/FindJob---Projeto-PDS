import { Button, Checkbox, ListItemText, Slider, TextField } from "@material-ui/core";
import styled from "styled-components";

export const Container = styled.div`
    display: flex;
    height: 100vh;
    width: 100vw;
    position: relative;
    max-height: 100vh;
`;

export const OuterContainer = styled.div`
    margin: 0 auto;
    height: 100vh;
    width: 70%;
`;

export const StyledTitle = styled.div`
    padding-top: 32px;
    text-align: center;

    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 700;
    font-size: 48px;
    line-height: 56px;
    color: #1A202C;
`;

export const StyledRegisterButton = styled(Button)`
    margin-block: 32px;
    width: 100%;

    background-color: #004E85 !important;
    height: 50px !important;

    .MuiButton-label {
        color: #FFFFFF;
    }
`;

export const StyledButtonContainer = styled.div`
    display: block;
    margin: 0 auto;
    width: 60%;
`;

export const StyledRegisterInfoContainer = styled.div`
    width: 80%;
    margin: 0 auto;
    height: 80vh;
`;

export const RowContainer = styled.div`
    display: flex;
    height: 16%;
    margin-block: 0 auto;
    justify-content: space-between;
`;

export const InputContainer = styled.div`
    margin-block: auto;
`;

export const StyledInput = styled(TextField)`
    margin-block: 8px;
    width: 300px;
    heigth: 50px;
`;

export const FreelancerContainer = styled.div`
    height: 58%;
    overflow:auto;
`;

export const StyledAddAbilityButton = styled(Button)`
    background-color: #004E85 !important;
    height: 27px !important;
    width: 27px !important;

    .MuiButton-label {
        color: #FFFFFF;
        font-size: x-large;
    }
`;

export const StyledListItemText = styled(ListItemText)`
    padding-block: 0 !important;
    width: 100%;
    overflow: "hidden";
    textOverflow: "ellipsis";
`;

export const StyledSlider = styled(Slider)`
    color: #004E85 !important;
    width: 100%;
`;

export const StyledCheckbox = styled(Checkbox)`
`;