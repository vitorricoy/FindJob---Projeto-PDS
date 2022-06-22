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

    const [applied, setApplied] = React.useState(false);

    const getJob = async () => {
        try {
            const job: AxiosResponse<Job> = await axios.get(
                Constants.BASE_URL + "api/job",
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
        if (job) {
            for (let skill of job.skills || []) {
                elements.push(
                    <Skill>
                        {skill.name}
                    </Skill>
                );
            }
        }
        return elements;
    }

    const apply = () => {
        try {
            axios.post(
                Constants.BASE_URL + "api/job/apply", new ApplyJobInput(job.id, currentUser.id)
            ).then((res) => {
                setApplied(true);
            });
        } catch (error: any) {
            throw new Error(error)
        }
    };

    useEffect(() => {
        if (!Object.keys(job).length) {
            getJob().then(job => {
                for (let candidate of job.data.candidates) {
                    if (candidate.id === currentUser.id) {
                        setApplied(true);
                    }
                }
                console.log(job);
                setJob(job.data);
            });
        }
    }, []);

    return !Object.keys(job).length ? <div></div> : (
        <Container>
            <Header />

            <Body>

                <UpperDiv>
                    <TitleDiv>
                        {job.title}
                    </TitleDiv>
                    <PriceDiv data-testid="price-div">
                        R$ {job.payment}
                        {job.isPaymentByHour ?
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
                            <SkillsDiv data-testid="skills-div">
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

                    <LowerRightDiv>
                        <AboutClientContainer>
                            <AboutClientTitle>
                                Sobre o Cliente
                            </AboutClientTitle>
                            <AboutClientSubtitle>
                                <UserIcon src="../../default-user-icon.svg"></UserIcon>
                                {job.client.name}
                            </AboutClientSubtitle>
                            <AboutClientContent>
                                {job.client.email}
                            </AboutClientContent>
                        </AboutClientContainer>
                        <ApplyJobDiv>
                            <div style={{ textAlign: "center", marginBlock: "5%" }}>
                                <StyledButton data-testid="apply-button" variant="contained" onClick={apply} disabled={applied}> Candidatar-se </StyledButton>
                            </div>
                        </ApplyJobDiv>
                    </LowerRightDiv>
                </LowerDiv>
            </Body>

            <Footer />
        </Container>
    );

};