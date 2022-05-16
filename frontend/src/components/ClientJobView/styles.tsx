import { Button } from "@material-ui/core";
import styled from "styled-components";
import { Props } from "./ClientJobView";

export const Container = styled.div`
    width: 100vw;
    height: 95vh;
    position: relative;
    background-color: #E6E6E6;
    justify-content: space-between;
`;

export const Body = styled.div`
    height: 87.5vh;
    max-height: 87.5vh;
    display: flex;
    flex-direction: column;
`;

export const UpperDiv = styled.div`
    height: 15vh;
    max-height: 15vh;
    width: 100%;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 50px;
    line-height: 59px;
    color: #000000;
    display: flex;
    margin: 15px 20px 5px 20px;
    align-content: space-between;
`

export const TitleDiv = styled.div`
    width:70vw;
    overflow: auto;
`;

export const PriceDiv = styled.div`
    width:25vw;
    display: flex;
    align-items: center;
    margin-left: 20px;
`;

export const LowerDiv = styled.div`
    display: flex;
    background-color: white;
    flex-direction: row;
    height: 70.5vh;
    max-height: 70.5vh;
`

export const LowerLeftDiv = styled.div`
    width: 69vw;
    margin: 15px 0px 0px 1vw;
    display: flex;
    flex-direction: column;
`

export const LowerRightDiv = styled.div<Props>`
    width: 30vw;
    display: flex;
    flex-direction: column;
    align-items: center;
    align-content: center;
    justify-content: ${props => props.justifyContent};
`

export const ContainerAbility = styled.div`
    flex: 0 1 auto;
`

export const AbilityTitle = styled.div`
    margin-bottom: 10px;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 40px;
    line-height: 47px;

    color: #000000;
`

export const SkillsDiv = styled.div`
    display: flex;
    flex-flow: wrap;
    justify-content: flex-start;
`;

export const Skill = styled.div`
    line-height: 28px;
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
    margin-bottom: 10px;
    margin-top: 10px;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 40px;
    line-height: 47px;
    color: #000000;
`

export const DescriptionContent = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 400;
    font-size: 30px;
    line-height: 35px;
    overflow:auto
    color: #000000;

    overflow: auto;
    max-width:100%;
`

export const ContainerFreelancerList = styled.div`
    border-radius: 30px;
    padding: 20px;
    background-color: #E6E6E6;
    width: 20vw;
    max-height: 85%;
    overflow: auto;
`

export const FreelancerBidingContainer = styled.div`
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 10px;
    margin-top: 10px;
`

export const UserInfo = styled.div`
    display: flex;
    align-items: center;
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
`

export const UserIcon = styled.img`
    width: 40px;
    height: 40px;
    margin-right: 10px;
`

export const StyledHireButton = styled(Button)`
    width: 80%;
    height: 20px;
    background-color: #04C35C !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 10px;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

export const HireDiv = styled.div`
    height: 20%;
`;

export const AboutFreelancerContainer = styled.div`
    background: #E5E5E5;
    border-radius: 30px;
    padding:20px;
    display:flex;
    flex-direction:column;
    width: 20vw;
    justify-content: space-evenly;
    margin-top: 30px;
`

export const AboutFreelancerTitle = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 30px;
    line-height: 35px;
    color: #000000;
    margin-bottom: 15px;
`

export const AboutFreelancerSubtitle = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 25px;
    line-height: 158.5%;
    color: #000000;
    display: flex;
    align-items: center;
    align-content: center;
    
    margin-bottom: 15px;
`

export const AboutFreelancerContent = styled.div`
    font-family: 'Roboto Condensed', sans-serif;
    font-style: normal;
    font-weight: 500;
    font-size: 20px;
    line-height: 158.5%;
    color: #000000;
`

export const StyledRateButton = styled(Button)`
    width: 50%;
    height: 45px;
    background-color: #04C35C !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 18px;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

export const RatingDiv = styled.div`
   display: flex;
   margin: 20px 0px 20px 0px;

   font-family: 'Roboto Condensed', sans-serif;
   font-size: 20px;
`

export const StyledChatButton = styled(Button)`
    width: 35%;
    height: 45px;
    background-color: #3f51b5 !important;

    .MuiButton-label {
        font-family: 'Roboto Condensed', sans-serif;
        font-style: normal;
        font-weight: 700;
        font-size: 18px;
        color: white;
    }

    '&:hover': {
        boxShadow: black;
    }
`;

export const ChatAndRateJobDiv = styled.div`
    height: 20%;
`;