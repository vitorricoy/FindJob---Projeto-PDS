import Skill from "./Skill";
import User from "./User";

export default class Job {
    Id: string;
    Title: string;
    Description: string;
    Deadline: number;
    Payment: number;
    IsPaymentByHour: boolean;
    Skills: Skill[];
    Client: User;
    AssignedFreelancer: User;
    Active: boolean;
    Available: boolean;
    Candidates: User[];

    constructor(Id: string, Title: string, Description: string, Deadline: number, Payment: number, IsPaymentByHour: boolean, Skills: Skill[], Client: User, AssignedFreelancer: User, Active: boolean, Available: boolean, Candidates: User[]) {
        this.Id = Id;
        this.Title = Title;
        this.Description = Description;
        this.Deadline = Deadline;
        this.Payment = Payment;
        this.IsPaymentByHour = IsPaymentByHour;
        this.Skills = Skills;
        this.Client = Client;
        this.AssignedFreelancer = AssignedFreelancer;
        this.Active = Active;
        this.Available = Available;
        this.Candidates = Candidates;
    }
}