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

export function FreelancerJobView() {

    return (
        <Container>
            <Header />

            <Body>

                <UpperDiv>
                    <TitleDiv>
                        Logomarca estilo pontilismo para e-commerce de canecas bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla bla
                    </TitleDiv>
                    <PriceDiv>
                        R$ 40 <sub>/h</sub>
                    </PriceDiv>
                </UpperDiv>
                <LowerDiv>
                    <LowerLeftDiv>
                        <ContainerAbility>
                            <AbilityTitle>
                                Habilidades Necessárias
                            </AbilityTitle>
                            <SkillsDiv>
                                <Skill>
                                    Design Gráfico
                                </Skill>
                                <Skill>
                                    Imagens Vetorizadas
                                </Skill>
                                <Skill>
                                    Adobe Illustrator
                                </Skill>
                                <Skill>
                                    Adobe Photoshop
                                </Skill>

                            </SkillsDiv>
                        </ContainerAbility>
                        <ContainerDescription>
                            <DescriptionTitle>
                                Descrição
                            </DescriptionTitle>
                            <DescriptionContent>
                                <p style={{ marginTop: "0" }}>
                                    &emsp;Nulla dolor quam, auctor vel est quis, placerat vulputate urna. Aliquam sit amet tempor neque, eget volutpat mauris. Nulla ante sem, venenatis et nisi sed, vestibulum cursus turpis. Praesent ex nisl, rhoncus at elit quis, sollicitudin mattis elit. Nunc tincidunt orci quis ex tincidunt, a maximus ante maximus. Donec est magna, luctus ut semper sollicitudin, dapibus semper felis. In aliquet pharetra vulputate. Pellentesque quis volutpat enim. Nunc placerat porttitor leo ac tempor. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Quisque vulputate commodo ipsum nec fringilla.
                                </p>
                                <p>
                                    &emsp;Donec magna quam, interdum sed orci id, pellentesque feugiat est. Nullam tincidunt accumsan porta. Ut diam arcu, euismod sit amet metus ut, congue faucibus risus. Proin hendrerit dui ut urna molestie bibendum. Cras viverra eget nunc eget egestas. Suspendisse vulputate eu magna ac ullamcorper. Mauris egestas sem fermentum, sagittis ligula nec, porta mauris
                                </p>
                                <p>
                                    &emsp;Donec magna quam, interdum sed orci id, pellentesque feugiat est. Nullam tincidunt accumsan porta. Ut diam arcu, euismod sit amet metus ut, congue faucibus risus. Proin hendrerit dui ut urna molestie bibendum. Cras viverra eget nunc eget egestas. Suspendisse vulputate eu magna ac ullamcorper. Mauris egestas sem fermentum, sagittis ligula nec, porta mauris
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
                                John Doe
                            </AboutClientSubtitle>
                            <AboutClientContent>
                                E-mail: johndoe@example.com
                            </AboutClientContent>
                        </AboutClientContainer>
                        <ApplyJobDiv>
                            <div style={{ textAlign: "center", marginBlock: "5%" }}>
                                <StyledButton variant="contained"> Candidatar-se </StyledButton>
                            </div>
                        </ApplyJobDiv>
                    </LowerRightDiv>
                </LowerDiv>
            </Body>

            <Footer />
        </Container>
    );

};