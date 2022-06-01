import User from "./User";

export default class Message {
    id: string;
    content: string;
    sentTime: Date;
    sender: User;
    receiver: User;
    isRead: boolean;

    constructor(content: string, id: string, sentTime: Date, sender: User, receiver: User, isRead: boolean) {
        this.id = id;
        this.content = content;
        this.sentTime = sentTime;
        this.sender = sender;
        this.receiver = receiver;
        this.isRead = isRead;
    }
};