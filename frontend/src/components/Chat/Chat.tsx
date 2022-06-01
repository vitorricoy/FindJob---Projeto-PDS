
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
import React, { useEffect } from "react";
import CreateMessageInput from "../../models/CreateMessageInput";


export function Chat() {
    const [currentUser, setCurrentUser] = useGlobalState('currentUser');
    const [conversationUser, setConversationUser] = React.useState<User>({} as User);

    const [userChatElements, setUserChatElements] = React.useState<JSX.Element[]>([]);
    const [conversationElements, setConversationElements] = React.useState<JSX.Element[]>([]);

    const getUserChat = (conversationUser: User, currentUser: User) => {
        if (!Object.keys(conversationUser).length) {
            return null;
        }
        let elements: JSX.Element[] = [];
        elements.push(
            <ConversationHeader>
                <Avatar src={"../default-user-icon.svg"} name="Emily" />
                <ConversationHeader.Content userName={conversationUser.name} info={conversationUser.isFreelancer ? "Freelancer" : "Cliente"} />
            </ConversationHeader>
        );

        getConversationHistory(currentUser.id, conversationUser.id).then(messagesData => {
            let messages = messagesData.data;
            messages.reverse();
            messages = messages.filter(m => m.content);
            let messageElements = [];

            for (let i = 0; i < messages.length; i++) {
                if (i === 0 || new Date(messages[i].sentTime).toLocaleDateString() !== new Date(messages[i - 1].sentTime).toLocaleDateString()) {
                    messageElements.push(
                        <MessageSeparator>
                            {getFormatedDate(new Date(messages[i].sentTime))}
                        </MessageSeparator>
                    );
                }
                messageElements.push(
                    <Message key={0} model={{
                        message: messages[i].content,
                        sentTime: new Date(messages[i].sentTime).getHours() + ":" + new Date(messages[i].sentTime).getMinutes(),
                        direction: messages[i].receiver.id === currentUser.id ? 'incoming' : 'outgoing',
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
            setUserChatElements(elements);
        });

    }

    const getConversationsComponents = (currentUser: User) => {
        let conversations: JSX.Element[] = []
        getConversations(currentUser.id).then(usersData => {
            let users = usersData.data;
            let promises = [];
            for (let user of users) {
                promises.push(getLastSentMessage(currentUser.id, user.id));
            }
            Promise.all(promises).then((promisesData: AxiosResponse<MessageModel>[]) => {
                for (let i = 0; i < promisesData.length; i++) {
                    let message = promisesData[i].data;
                    let user = users[i];
                    if (!message.content) {
                        conversations.push(
                            <Conversation onClick={() => setConversationUser(user)} className="regular-conversation" key={user.id} name={user.name}>
                                <Avatar src={"../default-user-icon.svg"} />
                            </Conversation>
                        );
                    } else if (message.sender.id !== user.id) {
                        conversations.push(
                            <Conversation onClick={() => setConversationUser(user)} className="regular-conversation" key={user.id} name={user.name} info={"Você: " + message.content}>
                                <Avatar src={"../default-user-icon.svg"} />
                            </Conversation>
                        );
                    } else {
                        conversations.push(
                            <Conversation onClick={() => setConversationUser(user)} className="regular-conversation" key={user.id} name={user.name} info={user.name.split(' ')[0] + ": " + message.content}>
                                <Avatar src={"../default-user-icon.svg"} />
                            </Conversation>
                        );
                    }
                }
                setConversationElements(conversations);
            })

        })
    };

    useEffect(() => {
        getUserChat(conversationUser, currentUser);
        getConversationsComponents(currentUser);
    }, []);

    useEffect(() => {
        getUserChat(conversationUser, currentUser);
        getConversationsComponents(currentUser);
    }, [conversationUser]);

    const sendMessage = (textContent: string, currentUser: User, conversationUser: User) => {
        axios.post(Constants.BASE_URL + 'api/message', new CreateMessageInput(textContent, new Date(), currentUser.id, conversationUser.id))
            .then((res) => {
                getUserChat(conversationUser, currentUser);
            })
            .catch(function (error) {
                console.log(error);
            });
    };

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
                        {conversationElements}
                    </ConversationList>
                </Sidebar>
                <ChatContainerStyled>
                    {userChatElements}
                </ChatContainerStyled>
            </Container>
        </ChatStyle>
        <Footer />
    </div>;

}

const getFormatedDate = (date: Date): string => {
    let realDate = new Date(date);
    var weekDay = ["Domingo", "Segunda-feira", "Terça-feira", "Quarta-feira", "Quinta-feira", "Sexta-feira", "Sábado"][realDate.getDay()];
    var day = realDate.getDate();
    var month = ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"][realDate.getMonth()];
    var year = realDate.getFullYear();
    return weekDay + ", " + day + " de " + month + " de " + year;
}

const getConversations = async (userId: string): Promise<AxiosResponse<User[]>> => {
    try {
        const conversations: AxiosResponse<User[]> = await axios.get(
            Constants.BASE_URL + "api/message/chats",
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
            Constants.BASE_URL + "api/message/history",
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
            Constants.BASE_URL + "api/message/lastMessage",
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