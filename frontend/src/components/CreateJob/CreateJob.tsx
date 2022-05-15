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
} from "./styles";
import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";
import { Checkbox, FormControlLabel, FormGroup, List, ListItem, ListItemText, MenuItem, TextField } from "@material-ui/core";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from '@mui/icons-material/Delete';
import React from "react";

const currencies = [
    {
        value: 'BRL',
        label: 'R$',
    },
    {
        value: 'USD',
        label: 'US$',
    },
    {
        value: 'EUR',
        label: '€',
    },
    {
        value: 'BTC',
        label: '฿',
    },
    {
        value: 'JPY',
        label: '¥',
    },
];

export function CreateJob() {
    const [abilities, setAbilities] = React.useState<any[]>(["Java", "Python", "Habilidade Secreta Interessante", "Programação WEB"]);

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

    const [currency, setCurrency] = React.useState('BRL');

    const handleCurrencyChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurrency(event.target.value);
    };

    const [perHourChecked, setPerHourChecked] = React.useState<boolean>(false);
    const [totalChecked, setTotalChecked] = React.useState<boolean>(true);

    const handlePaymentMethodChange = (event: any) => {
        if (event === 'total' && perHourChecked || event === 'total' && totalChecked) {
            setTotalChecked(true);
            setPerHourChecked(false);
        } else if (event === 'hour' && totalChecked || event === 'hour' && perHourChecked) {
            setTotalChecked(false);
            setPerHourChecked(true);
        }
    };

    return (
        <Container>
            <Header />

            <Body>
                <LeftDiv>
                    <DescribeYourJobDiv>
                        <DescribeYourJobUp>
                            <br />Descreva seu job
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
                                <TitleTextField id="outlined-basic" variant="outlined" size="small" placeholder="Ex: Website de comércio de roupas online" />
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
                                />
                            </TitleDescription4>
                            <TitleDescription5>
                                Prazo: <DateTextField id="outlined-basic" variant="outlined" size="small" /> dias.
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
                                <List dense={true}>
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
                                </List>
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
                                {currency} <CurrencyTextField id="outlined-basic" variant="outlined" /> <sub>{totalChecked ? '' : '/hr'} </sub>
                            </Payment4>
                        </GrayPaper>
                    </PaymentDiv>

                    <PostJobDiv>
                        <div style={{ textAlign: "center", marginBlock: "5%" }}>
                            <StyledButton variant="contained"> Postar job </StyledButton>
                        </div>
                    </PostJobDiv>
                </RightDiv>
            </Body>

            <Footer />
        </Container>
    );
}