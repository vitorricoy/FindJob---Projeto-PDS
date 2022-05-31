import Skill from "./Skill";

export default class User {
    id: string;
    name: string;
    email: string;
    password: string;
    phone: string;
    isFreelancer: boolean;
    skills: Map<Skill, [number, number]>;

    constructor(Id: string, Name: string, Email: string, Password: string, Phone: string, IsFreelancer: boolean, Skills: Map<Skill, [number, number]>) {
        this.id = Id;
        this.name = Name;
        this.email = Email;
        this.password = Password;
        this.phone = Phone;
        this.isFreelancer = IsFreelancer;
        this.skills = Skills;
    }
}