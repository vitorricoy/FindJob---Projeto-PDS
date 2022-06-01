import { Button } from "@material-ui/core";
import styled from "styled-components";

export const Container = styled.div`
    width: 100vw;
    height: 100vh;
    background-color: #E6E6E6;
`;

export const Body = styled.div`
    height: 86.5vh;
    max-height: 86.5vh;
    overflow: hidden;
    display: flex;
    flex-direction: column;
`;

export const UpperDiv = styled.div`
    height: 18%;
    max-height: 18%;
    width: 100%;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 310%;
    line-height: 120%;
    color: #000000;
    display: flex;
    margin: 1% 2% 0.5% 2%;
    align-content: space-between;
`

export const TitleDiv = styled.div`
    width:70vw;
    overflow: auto;
`;

export const PriceDiv = styled.div`
    width:35vw;
    display: flex;
    align-items: center;
    margin-left: 2%;
`;

export const LowerDiv = styled.div`
    display: flex;
    background-color: white;
    flex-direction: row;
    overflow: hidden;
`

export const LowerLeftDiv = styled.div`
    width: 69vw;
    margin: 1.5% 0px 0px 1vw;
    display: flex;
    flex-direction: column;
`

export const LowerRightDiv = styled.div`
    width: 30vw;
    display: flex;
    flex-direction: column;
    align-items: center;
    align-content: center;
    padding-right: 4%;
    justify-content: space-between;
`

export const ContainerAbility = styled.div`
    flex: 0 1 auto;
`

export const AbilityTitle = styled.div`
    margin-bottom: 10px;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 250%;
    line-height: 120%;

    color: #000000;
`

export const SkillsDiv = styled.div`
    display: flex;
    flex-flow: wrap;
    justify-content: flex-start;
`;

export const Skill = styled.div`
    line-height: 180%;
    margin-inline: 1%;
    margin-block: 0.5%;
    border-radius: 10px;
    background-color: #3f51b5;
    color: white;
    max-height: 28px;
    padding-inline: 1%;
`

export const ContainerDescription = styled.div`
    flex: 1 1 auto;
    overflow: hidden;
    display: flex;
    flex-direction: column;
`

export const DescriptionTitle = styled.div`
    margin-bottom: 1.5%;
    margin-top: 1.5%;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 250%;
    line-height: 120%;
    color: #000000;
`

export const DescriptionContent = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 185%;
    line-height: 120%;
    overflow:auto
    color: #000000;

    overflow: auto;
    max-width:100%;
`

export const AboutClientContainer = styled.div`
    background: #E5E5E5;
    border-radius: 3vw;
    padding: 8%;
    display: flex;
    flex-direction: column;
    width: 20vw;
    max-height: 381vh;
    justify-content: space-evenly;
    margin-top: 10%;
`

export const AboutClientTitle = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 160%;
    line-height: 110%;
    color: #000000;
    margin-bottom: 7%;
`

export const AboutClientSubtitle = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 140%;
    line-height: 140%;
    color: #000000;
    display: flex;
    align-items: center;
    align-content: center;

    margin-bottom: 7%;
`

export const AboutClientContent = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 120%;
    line-height: 158.5%;
    color: #000000;
    word-wrap: break-word;
`

export const UserIcon = styled.img`
    width: 5vw;
    height: 5vw;
    margin-right: 10%;
`

export const StyledButton = styled(Button)`
    width: 100%;
    height: 50%;
    background-color: ${props => props.disabled ? "#E6E6E6" : "#04C35C"} !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 128%;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

export const ApplyJobDiv = styled.div`
    height: 20%;
`;