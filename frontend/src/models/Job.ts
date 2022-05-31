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
    Cliente: User;
    AssignedFreelancer: User;
    Active: boolean;
    Available: boolean;

    constructor(Id: string, Title: string, Description: string, Deadline: number, Payment: number, IsPaymentByHour: boolean, Skills: Skill[], Cliente: User, AssignedFreelancer: User, Active: boolean, Available: boolean) {
        this.Id = Id;
        this.Title = Title;
        this.Description = Description;
        this.Deadline = Deadline;
        this.Payment = Payment;
        this.IsPaymentByHour = IsPaymentByHour;
        this.Skills = Skills;
        this.Cliente = Cliente;
        this.AssignedFreelancer = AssignedFreelancer;
        this.Active = Active;
        this.Available = Available;
    }
}