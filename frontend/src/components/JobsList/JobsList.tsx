import { Header } from "../Header/Header";
import { Footer } from "../Footer/Footer";
import {
    Body,
    Container,
    CurrencyTextField,
    Filters1,
    Filters2,
    Filters3,
    Filters4,
    Filters5,
    Filters6,
    Filters7,
    FindJobsBottom,
    FindJobsUp,
    GrayPaper,
    JobsList1,
    JobsList2,
    ListItemDiv,
    RightDiv,
    SearchJobTextField,
    SkillField,
    Skills1,
    Skills2,
    Skills3,
    SkillsDiv,
    StyledAddSkillButton,
    StyledList,
} from "./styles";
import { LeftDiv } from "../CreateJob/styles";
import { Checkbox, Divider, FormControlLabel, IconButton, InputAdornment, List, ListItem, ListItemText, MenuItem, TextField, Typography } from "@material-ui/core";
import React, { useEffect } from "react";
import DeleteIcon from '@mui/icons-material/Delete';
import SearchIcon from '@mui/icons-material/Search';
import { ListItemButton } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { useGlobalState } from "../..";
import Job from "../../models/Job";
import axios, { AxiosResponse } from "axios";
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

export function JobsList() {
    const [currency, setCurrency] = React.useState('R$');

    const [currentUser, setCurrentUser] = useGlobalState('currentUser');

    const handleCurrencyChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setCurrency(event.target.value);
    };

    const [perHourChecked, setPerHourChecked] = React.useState<boolean>(false);
    const [totalChecked, setTotalChecked] = React.useState<boolean>(true);

    const [perHourTextFieldDisable, setPerHourTextFieldDisable] = React.useState<boolean>(true);
    const [totalTextFieldDisable, setTotalTextFieldDisable] = React.useState<boolean>(false);

    const handlePaymentMethodChange = (event: any) => {
        if ((event === 'total' && perHourChecked) || (event === 'total' && totalChecked)) {
            setTotalChecked(true);
            setTotalTextFieldDisable(false);
            setPerHourChecked(false);
            setPerHourTextFieldDisable(true);
        } else if ((event === 'hour' && totalChecked) || (event === 'hour' && perHourChecked)) {
            setTotalChecked(false);
            setTotalTextFieldDisable(true);
            setPerHourChecked(true);
            setPerHourTextFieldDisable(false);
        }
    };

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

    const [availableJobs, setAvailableJobs] = React.useState<Job[]>([]);

    const { myJobs } = useParams();

    const getJobs = async () => {
        try {
            console.log(currentUser);
            if (currentUser.isFreelancer && myJobs) {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/list",
                    {
                        params: {
                            "userId": currentUser.id
                        }
                    }
                );
            } else if (currentUser.isFreelancer && !myJobs) {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/search",
                    {
                        params: {
                            "userId": currentUser.id
                        }
                    }
                );
            } else {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/list",
                    {
                        params: {
                            "userId": currentUser.id
                        }
                    }
                );
            }
            return jobs;
        } catch (error: any) {
            throw new Error(error);
        }
    }

    useEffect(() => {
        if (!availableJobs.length) {
            getJobs().then(result => {
                setAvailableJobs(result.data)
            })
        }
    }, []);

    let navigate = useNavigate();

    const handleJobClick = (ref: string) => {
        if (ref.length > 0) {
            // TODO: Enviar o jobId
            (currentUser.isFreelancer ? navigate("/freelancer-job-view") : navigate("/client-job-view"));
        }
    };

    return (
        <Container>
            <Header />

            <Body>

                <LeftDiv style={{ width: "30%" }}>
                    <GrayPaper>
                        <Filters1>
                            Filtros
                        </Filters1>
                        <Filters2>
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
                        </Filters2>
                        <Filters3>
                            <div>
                                <FormControlLabel control={<Checkbox defaultChecked color="primary" onChange={() => handlePaymentMethodChange('total')} checked={totalChecked} />} label="Valor total" />
                            </div>
                            {currency} <CurrencyTextField disabled={totalTextFieldDisable} id="outlined-basic1" variant="outlined" size="small" /> - {currency} <CurrencyTextField disabled={totalTextFieldDisable} id="outlined-basic2" variant="outlined" size="small" />
                        </Filters3>
                        <Filters4>
                            <div>
                                <FormControlLabel control={<Checkbox color="primary" checked={perHourChecked} onChange={() => handlePaymentMethodChange('hour')} />} label="Por hora" />
                            </div>
                            {currency} <CurrencyTextField disabled={perHourTextFieldDisable} id="outlined-basic3" variant="outlined" size="small" /> /h - {currency} <CurrencyTextField disabled={perHourTextFieldDisable} id="outlined-basic4" variant="outlined" size="small" /> /h
                        </Filters4>
                        <Filters5>
                            Prazo
                        </Filters5>
                        <Filters6>
                            <CurrencyTextField id="outlined-basic5" variant="outlined" size="small" /> dias - <CurrencyTextField id="outlined-basic6" variant="outlined" size="small" /> dias
                        </Filters6>
                        <Filters7>
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
                                                <div style={{ height: "6%", width: "100%", display: "flex", alignItems: "center" }}>
                                                    <ListItemText
                                                        primary={ability}
                                                    />
                                                    <IconButton edge="end" aria-label="delete" onClick={() => handleDeleteSkill(ability)}>
                                                        <DeleteIcon />
                                                    </IconButton>
                                                </div>
                                            </ListItem>
                                        )
                                    }
                                    )}
                                </StyledList>
                            </Skills3>
                        </Filters7>
                    </GrayPaper>
                </LeftDiv>

                <RightDiv style={{ width: "70%" }}>
                    <div style={{ height: "20%" }}>
                        <FindJobsUp>
                            Encontre Jobs
                        </FindJobsUp>
                        <FindJobsBottom>
                            Escolha dentre centenas de opções de jobs o que melhor se adapta às suas habilidades e expectativa de ganho.
                        </FindJobsBottom>
                    </div>

                    <div style={{ height: "80%" }}>
                        <GrayPaper>
                            <JobsList1>
                                <SearchJobTextField
                                    id="job-search"
                                    variant="outlined"
                                    size="small"
                                    placeholder="Pesquise Jobs disponíveis"
                                    InputProps={{
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <SearchIcon />
                                            </InputAdornment>
                                        ),
                                    }}
                                />
                            </JobsList1>
                            <JobsList2>
                                <nav aria-label="main mailbox folders">
                                    <div style={{}}>
                                        <List dense={true}>
                                            {availableJobs.map(job => {
                                                return (
                                                    <ListItem key={job.id} style={{ display: "block" }}>
                                                        <ListItemDiv>
                                                            <ListItemButton onClick={() => handleJobClick(job.title)}>
                                                                <ListItemText
                                                                    disableTypography
                                                                    primary={<Typography variant="h5" style={{ color: '#000000' }}>{job.title}</Typography>}
                                                                    secondary={<Typography style={{ color: '#000000', overflow: 'hidden', maxHeight: "48px" }}>{job.description}</Typography>}
                                                                />
                                                            </ListItemButton>
                                                        </ListItemDiv>
                                                        <SkillsDiv>
                                                            {job.skills.map((skill: any) => {
                                                                return (
                                                                    <div style={{ lineHeight: "28px", marginInline: "1%", marginBlock: "0.5%", borderRadius: "10px", backgroundColor: "#3f51b5", color: "white", maxHeight: "28px", paddingInline: "1%" }}>
                                                                        {skill.name}
                                                                    </div>
                                                                )
                                                            })}
                                                        </SkillsDiv>
                                                        <Divider />
                                                    </ListItem>
                                                )
                                            })}
                                        </List>
                                    </div>
                                </nav>
                            </JobsList2>
                        </GrayPaper>
                    </div>

                </RightDiv>

            </Body>

            <Footer />
        </Container>
    );

};