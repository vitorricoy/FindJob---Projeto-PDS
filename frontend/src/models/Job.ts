import Skill from "./Skill";
import User from "./User";

export default class Job {
    id: string;
    title: string;
    description: string;
    deadline: number;
    payment: number;
    isPaymentByHour: boolean;
    skills: Skill[];
    client: User;
    assignedFreelancer: User;
    active: boolean;
    available: boolean;
    candidates: User[];

    constructor(Id: string, Title: string, Description: string, Deadline: number, Payment: number, IsPaymentByHour: boolean, Skills: Skill[], Client: User, AssignedFreelancer: User, Active: boolean, Available: boolean, Candidates: User[]) {
        this.id = Id;
        this.title = Title;
        this.description = Description;
        this.deadline = Deadline;
        this.payment = Payment;
        this.isPaymentByHour = IsPaymentByHour;
        this.skills = Skills;
        this.client = Client;
        this.assignedFreelancer = AssignedFreelancer;
        this.active = Active;
        this.available = Available;
        this.candidates = Candidates;
    }
}