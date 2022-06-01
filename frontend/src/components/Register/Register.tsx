import { List, ListItem } from "@material-ui/core";
import axios, { AxiosResponse } from "axios";
import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { setGlobalState } from "../..";
import CreateClientInput from "../../models/CreateClientInput";
import CreateFreelancerInput from "../../models/CreateFreelancerInput";
import CreateSkillInput from "../../models/CreateSkillInput";
import Skill from "../../models/Skill";
import { Constants } from "../../util/Constants";
import {
    Container,
    StyledTitle,
    StyledRegisterButton,
    StyledButtonContainer,
    StyledRegisterInfoContainer,
    InputContainer,
    StyledInput,
    RowContainer,
    FreelancerContainer,
    StyledAddAbilityButton,
    StyledSlider,
    StyledListItemText,
    StyledCheckbox,
    StyledFormControlLabel
} from "./styles";

export function Register() {
    const [checked, setChecked] = React.useState(false);
    const [skillLevel, setSkillLevel] = React.useState<any>({});
    const [newAbilityInput, setNewAbilityInput] = React.useState<boolean>(false);

    const [registeredSkills, setRegisteredSkills] = React.useState<any>({});

    const [abilities, setAbilities] = React.useState([] as Skill[]);

    const getSkills = async () => {
        try {
            const skills: AxiosResponse<Skill[]> = await axios.get(
                Constants.BASE_URL + "api/skill/all"
            );
            return skills;
        } catch (error: any) {
            throw new Error(error);
        }
    }

    useEffect(() => {
        getSkills().then(result => {
            setAbilities(result.data)
        })
    }, [newAbilityInput]);

    const [email, setEmail] = React.useState<string>("");
    const [password, setPassword] = React.useState<string>("");
    const [fullName, setFullName] = React.useState<string>("");
    const [phoneNumber, setPhoneNumber] = React.useState<string>("");

    const handleEmailChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setEmail(event.target.value);
    };

    const handlePasswordChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPassword(event.target.value);
    };

    const handleFullNameChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setFullName(event.target.value);
    };

    const handlePhoneNumberChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setPhoneNumber(event.target.value);
    };

    useEffect(() => {
        let obj: any = {};
        abilities.forEach((skill: any) => {
            obj[skill] = 0;
        })
        setRegisteredSkills(obj);
    }, [newAbilityInput, abilities]);

    const handleCheck = (event: React.ChangeEvent<HTMLInputElement>) => {
        setChecked(event.target.checked);
        setNewAbilityInput(false);
    };

    const handleSliderStop = (event: any, newValue: number | number[]) => {
        registeredSkills[event.target.ariaLabel] = newValue;
        setRegisteredSkills(registeredSkills);
    };

    const handleAddNewAbilityInput = () => {
        setNewAbilityInput(!newAbilityInput);
    };

    const [name, setName] = React.useState('');
    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setName(event.target.value);
    };

    const handleAddNewAbility = async (ability: string) => {
        if (ability.trim().length > 0) {
            axios.post(Constants.BASE_URL + 'api/skill', new CreateSkillInput(ability))
                .then((res) => {
                    setName("");
                    setNewAbilityInput(false);
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    };

    let navigate = useNavigate();

    const handleRegisterClick = (event: any) => {

        if (checked) {
            let skills = abilities;
            let ratings: any[] = Object.values(registeredSkills)

            const info = {
                "email": email,
                "password": password,
                "name": fullName,
                "phone": phoneNumber,
                "skills": skills.map(s => s.name),
                "ratings": ratings
            }

            axios.post(Constants.BASE_URL + 'api/user/register/freelancer', new CreateFreelancerInput(info.email, info.password, info.name, info.phone, info.skills, info.ratings))
                .then((res) => {
                    localStorage.setItem("currentUser", JSON.stringify(res.data));
                    setGlobalState("currentUser", res.data);
                })
                .catch(function (error) {
                    console.log(error);
                });

        } else {
            const info = {
                "email": email,
                "password": password,
                "name": fullName,
                "phone": phoneNumber,
            }

            axios.post(Constants.BASE_URL + 'api/user/register/client', new CreateClientInput(info.email, info.password, info.name, info.phone))
                .then((res) => {
                    localStorage.setItem("currentUser", JSON.stringify(res.data));
                    setGlobalState("currentUser", res.data);
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
        navigate("/home");
    }

    return (
        <Container>
            <StyledTitle>
                Cadastro
            </StyledTitle>

            <StyledRegisterInfoContainer>
                <RowContainer>
                    <InputContainer> <StyledInput onChange={handleEmailChange} value={email} variant="outlined" label="E-mail" InputLabelProps={{ shrink: true, required: true }} /> </InputContainer>

                    <InputContainer> <StyledInput onChange={handlePasswordChange} value={password} variant="outlined" label="Senha" type="password" InputLabelProps={{ shrink: true, required: true }} /> </InputContainer>
                </RowContainer>

                <RowContainer>
                    <InputContainer> <StyledInput onChange={handleFullNameChange} value={fullName} variant="outlined" label="Nome Completo" InputLabelProps={{ shrink: true, required: true }} /> </InputContainer>

                    <InputContainer> <StyledInput onChange={handlePhoneNumberChange} value={phoneNumber} variant="outlined" label="Telefone" InputLabelProps={{ shrink: true, required: true }} /> </InputContainer>
                </RowContainer>

                <div style={{ height: "8%", marginInline: "19%" }}>
                    <StyledFormControlLabel control={
                        <StyledCheckbox
                            checked={checked}
                            onChange={handleCheck}
                            inputProps={{ 'aria-label': 'controlled' }}
                            color="primary"
                        />
                    } label="Sou um freelancer" />
                </div>

                <FreelancerContainer>
                    {checked ?
                        <div>
                            <p style={{
                                fontFamily: "'Roboto Condensed', sans-serif",
                                fontStyle: "normal",
                                fontWeight: "600",
                                fontSize: "16px",
                                lineHeight: "16px",
                                marginBlock: "0",
                                marginInline: "19%",
                                color: "#4A5568"
                            }}>
                                Habilidades
                            </p>

                            <List style={{ marginInline: "19%", marginTop: "12px !important" }}>
                                {abilities.map(ability => {
                                    return (
                                        <ListItem style={{ justifyContent: "space-between", display: "flex" }} key={ability.name}>
                                            <div style={{ width: "40%", marginRight: "8px", overflow: "hidden", textOverflow: "ellipsis" }}>
                                                <StyledListItemText primary={ability.name} style={{ color: "#2D3748" }} />
                                            </div>
                                            <div style={{ width: "60%", marginLeft: "4px" }}>
                                                <StyledSlider
                                                    aria-label={ability.name}
                                                    defaultValue={0}
                                                    valueLabelDisplay="auto"
                                                    step={10}
                                                    marks
                                                    min={0}
                                                    max={100}
                                                    value={skillLevel[ability.name]}
                                                    onChangeCommitted={handleSliderStop}
                                                />
                                            </div>
                                        </ListItem>
                                    )
                                })}
                            </List>

                            <div style={{ display: "flex", alignItems: "center", marginInline: "19%" }}>
                                {newAbilityInput &&
                                    <div style={{ padding: "0 16px" }}>
                                        <StyledInput
                                            variant="standard"
                                            label="Nova habilidade"
                                            value={name}
                                            onChange={handleChange}
                                            onKeyPress={(ev) => {
                                                if (ev.key === 'Enter') {
                                                    handleAddNewAbility(name)
                                                }
                                            }} />
                                    </div>}

                                {!newAbilityInput && <StyledAddAbilityButton onClick={handleAddNewAbilityInput}>+</StyledAddAbilityButton>}
                            </div>
                        </div>
                        : null}
                </FreelancerContainer>
            </StyledRegisterInfoContainer>

            <StyledButtonContainer>
                <StyledRegisterButton onClick={handleRegisterClick}> Cadastrar </StyledRegisterButton>
            </StyledButtonContainer>
        </Container>
    );
}