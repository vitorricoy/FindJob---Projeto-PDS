import User from "./User";

export default class Message {
    Id: string;
    Content: string;
    SentTime: Date;
    Sender: User;
    Receiver: User;
    IsRead: boolean;

    constructor(content: string, id: string, sentTime: Date, sender: User, receiver: User, isRead: boolean) {
        this.Id = id;
        this.Content = content;
        this.SentTime = sentTime;
        this.Sender = sender;
        this.Receiver = receiver;
        this.IsRead = isRead;
    }
};