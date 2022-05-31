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
    AboutClientContent,
    AboutClientContainer,
    AboutClientTitle,
    AboutClientSubtitle,
    UserIcon,
    ApplyJobDiv,
    StyledButton
} from "./styles";
import { useParams } from "react-router-dom";
import React, { useEffect } from "react";
import Job from "../../models/Job";
import axios, { AxiosResponse } from "axios";
import { Constants } from "../../util/Constants";
import ApplyJobInput from "../../models/ApplyJobInput";
import { useGlobalState } from "../..";

export function FreelancerJobView() {

    const [currentUser, setCurrentUser] = useGlobalState('currentUser');
    const { jobId } = useParams();

    const [job, setJob] = React.useState({} as Job);

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
        for (let skill of job.Skills) {
            elements.push(
                <Skill>
                    {skill.Name}
                </Skill>
            );
        }
        return elements;
    }

    const apply = () => {
        try {
            axios.post(
                Constants.BASE_URL + "/api/job/apply", new ApplyJobInput(job.Id, currentUser.Id)
            );
        } catch (error: any) {
            throw new Error(error)
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
                        {job.Title}
                    </TitleDiv>
                    <PriceDiv>
                        R$ {job.Payment}
                        {!job.IsPaymentByHour ?
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
                                    {job.Description}
                                </p>
                            </DescriptionContent>
                        </ContainerDescription>
                    </LowerLeftDiv>

                    <LowerRightDiv>
                        <AboutClientContainer>
                            <AboutClientTitle>
                                Sobre o Cliente
                            </AboutClientTitle>
                            <AboutClientSubtitle>
                                <UserIcon src="default-user-icon.svg"></UserIcon>
                                {job.Client.Name}
                            </AboutClientSubtitle>
                            <AboutClientContent>
                                {job.Client.Email}
                            </AboutClientContent>
                        </AboutClientContainer>
                        <ApplyJobDiv>
                            <div style={{ textAlign: "center", marginBlock: "5%" }}>
                                <StyledButton variant="contained" onClick={apply}> Candidatar-se </StyledButton>
                            </div>
                        </ApplyJobDiv>
                    </LowerRightDiv>
                </LowerDiv>
            </Body>

            <Footer />
        </Container>
    );

};