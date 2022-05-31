import Skill from "./Skill";

export default class CreateFreelancerInput {
    Email: string;
    Password: string;
    Name: string;
    Phone: string;
    Skills: Skill[];
    Ratings: number[];

    constructor(email: string, password: string, name: string, phone: string, skills: Skill[], ratings:number[]) {
        this.Email = email;
        this.Password = password;
        this.Name = name;
        this.Phone = phone;
        this.Skills = skills;
        this.Ratings = ratings;
    }
};