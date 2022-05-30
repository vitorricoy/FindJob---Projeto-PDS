import Skill from "./Skill";

export default class User {
    Id: string;
    Name: string;
    Email: string;
    Password: string;
    Phone: string;
    IsFreelancer: boolean;
    Skills: Map<Skill, [number, number]>;

    constructor(Id: string, Name: string, Email: string, Password: string, Phone: string, IsFreelancer: boolean, Skills: Map<Skill, [number, number]>) {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Password = Password;
        this.Phone = Phone;
        this.IsFreelancer = IsFreelancer;
        this.Skills = Skills;
    }
}