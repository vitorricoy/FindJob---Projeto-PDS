import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";
import {
    Container,
    UpperDiv,
    Body,
    TitleDiv,
    PriceDiv,
    LowerDiv,
    LowerLeftDiv,
    LowerRightDiv,
    ContainerAbility,
    AbilityTitle,
    SkillsDiv,
    Skill,
    ContainerDescription,
    DescriptionTitle,
    DescriptionContent,
    ContainerFreelancerList,
    FreelancerBidingContainer,
    UserIcon,
    HireDiv,
    StyledHireButton,
    StyledRateButton,
    AboutFreelancerContent,
    AboutFreelancerContainer,
    AboutFreelancerTitle,
    AboutFreelancerSubtitle,
    UserInfo,
    ChatAndRateJobDiv,
    StyledChatButton,
    RatingDiv,
    UserName,
    FreelancerIcon
} from "./styles";
import { Divider } from "@material-ui/core";
import React, { FunctionComponent, useEffect } from "react";
import { Rating } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { useGlobalState } from "../..";
import Job from "../../models/Job";
import { Constants } from "../../util/Constants";
import axios, { AxiosResponse } from "axios";
import RateJobInput from "../../models/RateJobInput";
import CreateMessageInput from "../../models/CreateMessageInput";

export interface Props {
    justifyContent: string;
}

export function ClientJobView() {

    const [currentUser, setCurrentUser] = useGlobalState('currentUser');
    const { jobId } = useParams();

    const [job, setJob] = React.useState({} as Job);
    const [rating, setRating] = React.useState(0);

    let navigate = useNavigate();

    const getJob = async () => {
        try {
            const job: AxiosResponse<Job> = await axios.get(
                Constants.BASE_URL + "/api/job",
                {
                    params: {
                        'jobId': jobId
                    }
                }
            );
            return job;
        } catch (error: any) {
            throw new Error(error)
        }
    }

    const getJobSkills = (): JSX.Element[] => {
        let elements = []
        for (let skill of job.skills) {
            elements.push(
                <Skill>
                    {skill.name}
                </Skill>
            );
        }
        return elements;
    }

    const openChat = () => {
        // Cria mensagem vazia e redireciona
        axios.post('/api/message', new CreateMessageInput('', new Date(), currentUser.id, job.assignedFreelancer.id))
            .then(() => {
                navigate("/chat");
            })
            .catch(function (error) {
                console.log(error);
            });
    };

    const rateJob = () => {
        // Avalia
        try {
            axios.post(
                Constants.BASE_URL + "/api/job/rate", new RateJobInput(job.id, rating)
            );
        } catch (error: any) {
            throw new Error(error)
        }
    };

    const getFreelancerBidings = () => {
        let elements = []
        for (let freelancer of job.candidates) {
            elements.push(
                <FreelancerBidingContainer>
                    <UserInfo>
                        <UserIcon src="default-user-icon.svg"></UserIcon>
                        <UserName>{freelancer.name}</UserName>
                    </UserInfo>
                    <HireDiv>
                        <div style={{ textAlign: "center" }}>
                            <StyledHireButton variant="contained"> Contratar </StyledHireButton>
                        </div>
                    </HireDiv>
                </FreelancerBidingContainer>
            );
            elements.push(<Divider />);
        }
        elements.pop(); // Remove ultimo divider
        return elements;
    };

    const onRatingChange = (event: any, value: number | null) => {
        if (value) {
            setRating(value);
        }
    };

    useEffect(() => {
        if (!job) {
            getJob().then(job => {
                setJob(job.data);
            });
        }
    }, []);

    return (
        <Container>
            <Header />

            <Body>

                <UpperDiv>
                    <TitleDiv>
                        {job.title}
                    </TitleDiv>
                    <PriceDiv>
                        R$ {job.payment}
                        {!job.isPaymentByHour ?
                            <sub>/h</sub>
                            :
                            null}
                    </PriceDiv>
                </UpperDiv>
                <LowerDiv>
                    <LowerLeftDiv>
                        <ContainerAbility>
                            <AbilityTitle>
                                Habilidades Necessárias
                            </AbilityTitle>
                            <SkillsDiv>
                                {
                                    getJobSkills()
                                }
                            </SkillsDiv>
                        </ContainerAbility>
                        <ContainerDescription>
                            <DescriptionTitle>
                                Descrição
                            </DescriptionTitle>
                            <DescriptionContent>
                                <p style={{ marginTop: "0" }}>
                                    {job.description}
                                </p>
                            </DescriptionContent>
                        </ContainerDescription>
                    </LowerLeftDiv>

                    <LowerRightDiv justifyContent={job.available ? "space-between" : "center"}>
                        {
                            job.available ?
                                (
                                    <div style={{ display: "flex", flexDirection: "column", justifyContent: "space-between", alignItems: "center", alignContent: "center" }}>
                                        <AboutFreelancerContainer>
                                            <AboutFreelancerTitle>
                                                Sobre o Freelancer Contratado
                                            </AboutFreelancerTitle>
                                            <AboutFreelancerSubtitle>
                                                <FreelancerIcon src="default-user-icon.svg"></FreelancerIcon>
                                                {job.assignedFreelancer.name}
                                            </AboutFreelancerSubtitle>
                                            <AboutFreelancerContent>
                                                {job.assignedFreelancer.email}
                                            </AboutFreelancerContent>
                                        </AboutFreelancerContainer>
                                        <RatingDiv>
                                            <span style={{ marginTop: "4px", marginRight: "4px" }}>Avaliação: </span>
                                            <Rating onChange={onRatingChange} name="half-rating" defaultValue={0.0} precision={0.2} size="large" style={{ fontSize: "140%" }} />
                                        </RatingDiv>
                                        <ChatAndRateJobDiv>
                                            <div style={{ textAlign: "center", marginBlock: "5%", display: "flex", justifyContent: "space-evenly" }}>
                                                <StyledChatButton onClick={openChat} variant="contained"> Chat </StyledChatButton>
                                                <StyledRateButton onClick={rateJob} variant="contained"> Avaliar </StyledRateButton>
                                            </div>
                                        </ChatAndRateJobDiv>
                                    </div>
                                ) : (
                                    (<ContainerFreelancerList>
                                        {getFreelancerBidings()}
                                    </ContainerFreelancerList>)
                                )
                        }
                    </LowerRightDiv>
                </LowerDiv>
            </Body>

            <Footer />
        </Container >
    );

};