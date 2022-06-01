export default class CreateJobInput {
    Title: string;
    Description: string;
    Deadline: number;
    Payment: number;
    IsPaymentByHour: boolean;
    Skills: string[];
    ClientId: string;

    constructor(title: string, description: string, deadline: number, payment: number, isPaymentByHour: boolean, skills: string[], clientId: string) {
        this.Title = title;
        this.Description = description;
        this.Deadline = deadline;
        this.Payment = payment;
        this.IsPaymentByHour = isPaymentByHour;
        this.Skills = skills;
        this.ClientId = clientId;
    }
};