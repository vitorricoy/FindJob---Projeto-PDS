export default class CreateClientInput {
    Email: string;
    Password: string;
    Name: string;
    Phone: string;

    constructor(email: string, password: string, name: string, phone: string) {
        this.Email = email;
        this.Password = password;
        this.Name = name;
        this.Phone = phone;
    }
};