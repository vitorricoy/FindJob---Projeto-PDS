import {
    Body,
    Container,
    DescribeYourJobDiv,
    LeftDiv,
    PaymentDiv,
    PostJobDiv,
    RightDiv,
    SkillsDiv,
    TitleDescriptionDiv,
    GrayPaper,
    DescribeYourJobUp,
    DescribeYourJobBottom,
    TitleDescription1,
    TitleDescription2,
    TitleDescription3,
    TitleDescription4,
    TitleDescription5,
    TitleTextField,
    DescriptionTextField,
    DateTextField,
    Skills1,
    Skills2,
    Skills3,
    SkillField,
    StyledAddSkillButton,
    StyledButton,
    Payment1,
    Payment2,
    Payment3,
    Payment4,
    CurrencyTextField,
    StyledList,
} from "./styles";
import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";
import { Checkbox, FormControlLabel, FormGroup, List, ListItem, ListItemText, MenuItem, TextField } from "@material-ui/core";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from '@mui/icons-material/Delete';
import React from "react";
import { useNavigate } from "react-router-dom";
import { Payment } from "@mui/icons-material";
import axios from "axios";
import CreateJobInput from "../../models/CreateJobInput";
import { useGlobalState } from "../..";
import { Constants } from "../../util/Constants";

const currencies = [
    {
        value: 'R$',
        label: 'Real (BRL)',
    },
    {
        value: 'US$',
        label: 'Dólar (USD)',
    },
    {
        value: '€',
        label: 'Euro (EUR)',
    },
    {
        value: '¥',
        label: 'Iene (JPY)',
    },
];

export function CreateJob() {
    const [abilities, setAbilities] = React.useState<any[]>([]);

    const handleDeleteSkill = (ability: string) => {
        let newSkills = abilities.filter(skill => skill !== ability);
        setAbilities(newSkills);
    };

    const [name, setName] = React.useState('');
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleAddNewAbility = (ability: string) => {
        if (ability.trim().length > 0) {
            let newAbilities = abilities;
            newAbilities.push(ability);
            setAbilities(newAbilities);
        }
        setName("");
    };

    const [perHourChecked, setPerHourChecked] = React.useState<boolean>(false);
    const [totalChecked, setTotalChecked] = React.useState<boolean>(true);
    const [title, setTitle] = React.useState<string>("");
    const [description, setDescription] = React.useState<string>("");
    const [deadline, setDeadline] = React.useState<string>("");
    const [currency, setCurrency] = React.useState('R$');
    const [payment, setPayment] = React.useState<string>("");
    const [currentUser, setCurrentUser] = useGlobalState('currentUser');

    const handleCurrencyChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurrency(event.target.value);
    };

    const handlePaymentMethodChange = (event: any) => {
        if (event === 'total' && perHourChecked || event === 'total' && totalChecked) {
            setTotalChecked(true);
            setPerHourChecked(false);
        } else if (event === 'hour' && totalChecked || event === 'hour' && perHourChecked) {
            setTotalChecked(false);
            setPerHourChecked(true);
        }
    };

    let navigate = useNavigate();

    const handleTitleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setTitle(event.target.value);
    };

    const handleDescriptionChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDescription(event.target.value);
    };

    const handleDeadlineChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setDeadline(event.target.value);
    };

    const handlePaymentChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPayment(event.target.value);
    };

    const handleButtonClick = (event: any) => {
        const job = {
            "title": title,
            "description": description,
            "deadline": deadline,
            "payment": payment,
            "isPaymentByHour": perHourChecked,
            "skills": abilities,
            "clientId": currentUser.id
        };
        console.log(job)
        axios.post(Constants.BASE_URL + 'api/job', new CreateJobInput(job.title, job.description, parseInt(job.deadline), Number(job.payment), job.isPaymentByHour, job.skills, job.clientId))
            .catch(function (error) {
                console.log(error);
            });

        return navigate("/jobs-list/true");
    }

    return (
        <Container>
            <Header />

            <Body>
                <LeftDiv>
                    <DescribeYourJobDiv>
                        <DescribeYourJobUp>
                            Descreva seu job
                        </DescribeYourJobUp>

                        <DescribeYourJobBottom style={{ margin: "auto", width: "90%", height: "40%" }}>
                            Diga-nos o que precisa ser feito e encontraremos os freelancers ideais para você. Você defines seus limites.
                        </DescribeYourJobBottom>
                    </DescribeYourJobDiv>

                    <TitleDescriptionDiv>
                        <GrayPaper>
                            <TitleDescription1>
                                Título
                            </TitleDescription1>
                            <TitleDescription2>
                                <TitleTextField onChange={handleTitleChange} value={title} id="outlined-basic" variant="outlined" size="small" placeholder="Ex: Website de comércio de roupas online" />
                            </TitleDescription2>
                            <TitleDescription3>
                                Descrição
                            </TitleDescription3>
                            <TitleDescription4>
                                <DescriptionTextField
                                    id="standard-multiline-static"
                                    multiline
                                    rows={10}
                                    variant="outlined"
                                    placeholder="Ex: Preciso de um desenvolvedor capaz de..."
                                    onChange={handleDescriptionChange}
                                    value={description}
                                />
                            </TitleDescription4>
                            <TitleDescription5>
                                Prazo: <DateTextField onChange={handleDeadlineChange} value={deadline} id="outlined-basic" variant="outlined" size="small" /> dias.
                            </TitleDescription5>
                        </GrayPaper>
                    </TitleDescriptionDiv>
                </LeftDiv>

                <RightDiv>
                    <SkillsDiv>
                        <GrayPaper>
                            <Skills1>
                                Habilidades
                            </Skills1>
                            <Skills2>
                                <SkillField
                                    id="outlined-basic"
                                    variant="outlined"
                                    size="small"
                                    value={name}
                                    onChange={handleChange}
                                />
                                <StyledAddSkillButton
                                    onClick={() => handleAddNewAbility(name)}
                                >+</StyledAddSkillButton>
                            </Skills2>
                            <Skills3>
                                <StyledList dense={true}>
                                    {abilities.map(ability => {
                                        return (
                                            <ListItem>
                                                <ListItemText
                                                    primary={ability}
                                                />
                                                <IconButton edge="end" aria-label="delete" onClick={() => handleDeleteSkill(ability)}>
                                                    <DeleteIcon />
                                                </IconButton>
                                            </ListItem>
                                        )
                                    }
                                    )}
                                </StyledList>
                            </Skills3>
                        </GrayPaper>
                    </SkillsDiv>

                    <PaymentDiv>
                        <GrayPaper>
                            <Payment1>
                                Pagamento ofertado
                            </Payment1>
                            <Payment2>
                                <TextField
                                    id="outlined-select-currency"
                                    select
                                    label="Moeda"
                                    value={currency}
                                    onChange={handleCurrencyChange}
                                    style={{ width: "100%" }}
                                >
                                    {currencies.map((option) => (
                                        <MenuItem key={option.value} value={option.value}>
                                            {option.label}
                                        </MenuItem>
                                    ))}
                                </TextField>
                            </Payment2>
                            <Payment3>
                                <FormGroup>
                                    <div style={{ display: "flex" }}>
                                        <FormControlLabel control={<Checkbox defaultChecked color="primary" onChange={() => handlePaymentMethodChange('total')} checked={totalChecked} />} label="Valor total" />
                                        <FormControlLabel control={<Checkbox color="primary" checked={perHourChecked} onChange={() => handlePaymentMethodChange('hour')} />} label="Por hora" />
                                    </div>
                                </FormGroup>
                            </Payment3>
                            <Payment4>
                                {currency} <CurrencyTextField onChange={handlePaymentChange} value={payment} id="outlined-basic" variant="outlined" /> <sub>{totalChecked ? '' : '/h'} </sub>
                            </Payment4>
                        </GrayPaper>
                    </PaymentDiv>

                    <PostJobDiv>
                        <div style={{ textAlign: "center", marginBlock: "5%" }}>
                            <StyledButton variant="contained" onClick={handleButtonClick}> Postar job </StyledButton>
                        </div>
                    </PostJobDiv>
                </RightDiv>
            </Body>

            <Footer />
        </Container>
    );
}