
import {
    MessageList,
    MessageInput,
    Sidebar,
    MessageSeparator,
    ConversationList,
    Conversation,
    ConversationHeader,
    Avatar,
    Message
} from "@chatscope/chat-ui-kit-react";
import axios, { AxiosResponse } from "axios"
import { Footer } from "../Footer/Footer";
import { Header } from "../Header/Header";
import MessageModel from "../../models/Message";
import { useGlobalState } from "../..";

import {
    ChatContainerStyled,
    Container,
    ChatStyle,
    MessagesTextTitle
} from "./styles";
import { Constants } from "../../util/Constants";
import User from "../../models/User";
import React from "react";
import CreateMessageInput from "../../models/CreateMessageInput";


export function Chat() {
    const [currentUser, setCurrentUser] = useGlobalState('currentUser');
    const [conversationUser, setConversationUser] = React.useState<User>();

    return <div>
        <Header />
        <ChatStyle>
            <Container>
                <Sidebar position="left">
                    <ConversationList>
                        <Conversation className="title-conversation">
                            <Avatar className="title-avatar">
                                <MessagesTextTitle>
                                    <p>CONVERSAS</p>
                                </MessagesTextTitle>
                            </Avatar>
                        </Conversation>
                        {getConversationsComponents(currentUser, setConversationUser)}
                    </ConversationList>
                </Sidebar>
                <ChatContainerStyled>
                    {getUserChat(conversationUser!, currentUser)}
                </ChatContainerStyled>
            </Container>
        </ChatStyle>
        <Footer />
    </div>;

}

const getUserChat = async (conversationUser: User, currentUser: User) => {

    let elements: JSX.Element[] = [];
    elements.push(
        <ConversationHeader>
            <Avatar src={"default-user-icon.svg"} name="Emily" />
            <ConversationHeader.Content userName="Emily" info="Freelancer" />
        </ConversationHeader>
    );

    let messages: MessageModel[] = (await getConversationHistory(currentUser.Id, conversationUser.Id)).data;

    let messageElements = [];

    for (let i = 0; i < messages.length; i++) {
        if (!messages[i].Content) {
            continue;
        }
        if (i === 0 || messages[i].SentTime.toLocaleDateString() !== messages[i - 1].SentTime.toLocaleDateString()) {
            messageElements.push(
                <MessageSeparator>
                    {getFormatedDate(messages[i].SentTime)}
                </MessageSeparator>
            );
        }
        messageElements.push(
            <Message key={0} model={{
                message: messages[i].Content,
                sentTime: messages[i].SentTime.getHours() + ":" + messages[i].SentTime.getMinutes(),
                direction: messages[i].Receiver.Id === currentUser.Id ? 'incoming' : 'outgoing',
                position: "single"
            }} />
        );
    }

    elements.push(
        <MessageList>
            {messageElements}
        </MessageList>
    );
    elements.push(
        <MessageInput attachButton={false} placeholder="Digite sua mensagem..." onSend={(innerHtml: String, textContent: String, innerText: String, nodes: NodeList) => sendMessage(textContent as string, currentUser, conversationUser)} />
    );
    return elements;
}

const sendMessage = (textContent: string, currentUser: User, conversationUser: User) => {
    axios.post('/api/message', new CreateMessageInput(textContent, new Date(), currentUser.Id, conversationUser.Id))
        .catch(function (error) {
            console.log(error);
        });
};

const getFormatedDate = (date: Date): string => {
    var weekDay = ["Domingo", "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado"][date.getDay()];
    var day = date.getDate();
    var month = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"][date.getMonth()];
    var year = date.getFullYear();
    return weekDay + ", " + day + " de " + month + " de " + year;
}

const getConversationsComponents = async (user: User, setConversationUser: React.Dispatch<React.SetStateAction<User | undefined>>): Promise<JSX.Element[]> => {
    let conversations: JSX.Element[] = []
    let users = (await getConversations(user.Id)).data;
    for (let user of users) {
        let message = (await getLastSentMessage(user.Id, user.Id)).data;
        if (!message.Content) {
            conversations.push(
                <Conversation onClick={setConversationUser(user)} className="regular-conversation" key={user.Id} name={user.Name}>
                    <Avatar src={"default-user-icon.svg"} />
                </Conversation>
            );
        } else if (message.Sender.Id === user.Id) {
            conversations.push(
                <Conversation onClick={setConversationUser(user)} className="regular-conversation" key={user.Id} name={user.Name} info={"Você: " + message.Content}>
                    <Avatar src={"default-user-icon.svg"} />
                </Conversation>
            );
        } else {
            conversations.push(
                <Conversation className="regular-conversation" key={user.Id} name={user.Name} info={user.Name.split(' ')[0] + ": " + message.Content}>
                    <Avatar src={"default-user-icon.svg"} />
                </Conversation>
            );
        }
    }
    return conversations;
};

const getConversations = async (userId: string): Promise<AxiosResponse<User[]>> => {
    try {
        const conversations: AxiosResponse<User[]> = await axios.get(
            Constants.BASE_URL + "/api/message/chats",
            {
                params: {
                    'userId': userId
                }
            }
        );
        return conversations;
    } catch (error: any) {
        throw new Error(error)
    }
}

const getConversationHistory = async (userId1: string, userId2: string): Promise<AxiosResponse<MessageModel[]>> => {
    try {
        const conversations: AxiosResponse<MessageModel[]> = await axios.get(
            Constants.BASE_URL + "/api/message/history",
            {
                params: {
                    'userId1': userId1,
                    'userId2': userId2
                }
            }
        );
        return conversations;
    } catch (error: any) {
        throw new Error(error)
    }
}

const getLastSentMessage = async (userId1: string, userId2: string): Promise<AxiosResponse<MessageModel>> => {
    try {
        const conversations: AxiosResponse<MessageModel> = await axios.get(
            Constants.BASE_URL + "/api/message/lastMessage",
            {
                params: {
                    'userId1': userId1,
                    'userId2': userId2
                }
            }
        );
        return conversations;
    } catch (error: any) {
        throw new Error(error)
    }
}

export default Chat;