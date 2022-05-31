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
import Skill from "../../models/Skill";

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
    const [perHourPaymentMin, setPerHourPaymentMin] = React.useState();
    const [perHourPaymentMax, setPerHourPaymentMax] = React.useState();

    const [totalChecked, setTotalChecked] = React.useState<boolean>(false);
    const [totalPaymentMin, setTotalPaymentMin] = React.useState();
    const [totalPaymentMax, setTotalPaymentMax] = React.useState();

    const [perHourTextFieldDisable, setPerHourTextFieldDisable] = React.useState<boolean>(true);
    const [totalTextFieldDisable, setTotalTextFieldDisable] = React.useState<boolean>(true);

    const [deadlineMin, setDeadlineMin] = React.useState();
    const [deadlineMax, setDeadlineMax] = React.useState();

    const [searchQuery, setSearchQuery] = React.useState("");

    const handlePaymentMethodChange = (event: any) => {
        if ((event === 'total')) {
            setTotalChecked(!totalChecked);
            setTotalTextFieldDisable(!totalTextFieldDisable);
            setPerHourChecked(false);
            setPerHourTextFieldDisable(true);
        } else if (event === 'hour') {
            setTotalChecked(false);
            setTotalTextFieldDisable(true);
            setPerHourChecked(!perHourChecked);
            setPerHourTextFieldDisable(!perHourTextFieldDisable);
        }
    };

    const handleTotalPaymentMinChange = (event: any) => {
        setTotalPaymentMin(event.target.value);
    }

    const handleTotalPaymentMaxChange = (event: any) => {
        setTotalPaymentMax(event.target.value);
    }

    const handlePerHourPaymentMinChange = (event: any) => {
        setPerHourPaymentMin(event.target.value);
    }

    const handlePerHourPaymentMaxChange = (event: any) => {
        setPerHourPaymentMax(event.target.value);
    }

    function checkPaymentInterval(price: number) {
        if (totalChecked) {
            if (price >= (totalPaymentMin? totalPaymentMin : 0) && price <= (totalPaymentMax? totalPaymentMax : Number.POSITIVE_INFINITY)) { return true }
            else { return false }
        } else if (perHourChecked) {
            if (price >= (perHourPaymentMin? perHourPaymentMin : 0) && price <= (perHourPaymentMax? perHourPaymentMax : Number.POSITIVE_INFINITY)) { return true }
            else { return false }
        } else {
            return true;
        }
    }

    function checkPaymentType(isPaymentByHour: boolean) {
        if (isPaymentByHour && totalChecked) {
            return false;
        } else if (!isPaymentByHour && perHourChecked) {
            return false;
        }
        return true;
    }

    const handleDeadlineMinChange = (event: any) => {
        setDeadlineMin(event.target.value);
    }

    const handleDeadlineMaxChange = (event: any) => {
        setDeadlineMax(event.target.value);
    }

    function checkDeadlineInterval(deadline: number) {
        if (deadline >= (deadlineMin? deadlineMin : 0) && deadline <= (deadlineMax? deadlineMax : Number.POSITIVE_INFINITY)) {
             return true 
        }
        return false;
    }

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

    function checkSkills (skills: Skill[]) {
        if (abilities.length > 0) {
            let jobSkills = skills.map(skill => {
                return skill.Name;
            });

            if (JSON.stringify(abilities.sort()) !== JSON.stringify(jobSkills.sort())) {
                return false
            }
        }
        return true;
    }

    const handleSearchQueryChange = (event: any) => {
        setSearchQuery(event.target.value)
    }

    function checkSearchQuery (title: string) {
        if (searchQuery && searchQuery.length > 0 && !title.includes(searchQuery)) {
            return false;
        }
        return true;
    }

    const [availableJobs, setAvailableJobs] = React.useState<Job[]>([]);

    const { myJobs } = useParams();

    const getJobs = async () => {
        try {
            if (currentUser.IsFreelancer && myJobs) {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/list",
                    {
                        params: {
                            "userId": currentUser.Id
                        }
                    }
                );
            } else if (currentUser.IsFreelancer && !myJobs) {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/search",
                    {
                        params: {
                            "userId": currentUser.Id
                        }
                    }
                );
            } else {
                var jobs: AxiosResponse<Job[]> = await axios.get(
                    Constants.BASE_URL + "api/job/list",
                    {
                        params: {
                            "userId": currentUser.Id
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
        if (availableJobs.length) {
            getJobs().then(result => {
                setAvailableJobs(result.data)
            })
        }
    }, []);

    let navigate = useNavigate();

    const handleJobClick = (ref: string) => {
        if (ref.length > 0) {
            // TODO: Enviar o jobId
            (currentUser.IsFreelancer ? navigate("/freelancer-job-view") : navigate("/client-job-view"));
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
                            {currency} <CurrencyTextField onChange={handleTotalPaymentMinChange} value={totalPaymentMin} disabled={totalTextFieldDisable} id="outlined-basic1" variant="outlined" size="small" /> - 
                            {currency} <CurrencyTextField onChange={handleTotalPaymentMaxChange} value={totalPaymentMax} disabled={totalTextFieldDisable} id="outlined-basic2" variant="outlined" size="small" />
                        </Filters3>
                        <Filters4>
                            <div>
                                <FormControlLabel control={<Checkbox color="primary" checked={perHourChecked} onChange={() => handlePaymentMethodChange('hour')} />} label="Por hora" />
                            </div>
                            {currency} <CurrencyTextField onChange={handlePerHourPaymentMinChange} value={perHourPaymentMin} disabled={perHourTextFieldDisable} id="outlined-basic3" variant="outlined" size="small" /> /h - 
                            {currency} <CurrencyTextField onChange={handlePerHourPaymentMaxChange} value={perHourPaymentMax} disabled={perHourTextFieldDisable} id="outlined-basic4" variant="outlined" size="small" /> /h
                        </Filters4>
                        <Filters5>
                            Prazo
                        </Filters5>
                        <Filters6>
                            <CurrencyTextField onChange={handleDeadlineMinChange} value={deadlineMin} id="outlined-basic5" variant="outlined" size="small" /> dias - 
                            <CurrencyTextField onChange={handleDeadlineMaxChange} value={deadlineMax} id="outlined-basic6" variant="outlined" size="small" /> dias
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
                                    onChange={handleSearchQueryChange}
                                    value={searchQuery}
                                />
                            </JobsList1>
                            <JobsList2>
                                <nav aria-label="main mailbox folders">
                                    <div style={{}}>
                                        <List dense={true}>
                                            {availableJobs.map(job => {
                                                if (checkPaymentInterval(job.Payment) && checkPaymentType(job.IsPaymentByHour) && checkDeadlineInterval(job.Deadline) && checkSkills(job.Skills) && checkSearchQuery(job.Title)) {
                                                    return (
                                                        <ListItem style={{ display: "block" }}>
                                                            <ListItemDiv>
                                                                <ListItemButton onClick={() => handleJobClick(job.Title)}>
                                                                    <ListItemText
                                                                        disableTypography
                                                                        primary={<Typography variant="h5" style={{ color: '#000000' }}>{job.Title}</Typography>}
                                                                        secondary={<Typography style={{ color: '#000000', overflow: 'hidden', maxHeight: "48px" }}>{job.Description}</Typography>}
                                                                    />
                                                                </ListItemButton>
                                                            </ListItemDiv>
                                                            <SkillsDiv>
                                                                {job.Skills.map((skill: any) => {
                                                                    return (
                                                                        <div style={{ lineHeight: "28px", marginInline: "1%", marginBlock: "0.5%", borderRadius: "10px", backgroundColor: "#3f51b5", color: "white", maxHeight: "28px", paddingInline: "1%" }}>
                                                                            {skill.Name}
                                                                        </div>
                                                                    )
                                                                })}
                                                            </SkillsDiv>
                                                            <Divider />
                                                        </ListItem>
                                                    )
                                                }
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