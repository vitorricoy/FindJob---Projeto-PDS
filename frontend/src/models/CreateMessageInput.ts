export default class CreateMessageInput {
    Text: string;
    SentTime: Date;
    SenderId: string;
    ReceiverId: string;

    constructor(text: string, sentTime: Date, senderId: string, receiverId: string) {
        this.Text = text;
        this.SentTime = sentTime;
        this.SenderId = senderId;
        this.ReceiverId = receiverId;
    }
};