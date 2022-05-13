
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
import { Footer } from "../Footer/Footer";
import { Header } from "../Header/Header";

import {
    ChatContainerStyled,
    Container,
    ChatStyle,
    MessagesTextTitle
} from "./styles";


export function Chat() {
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
                        <Conversation className="regular-conversation" key={0} name={"Emily"} lastSenderName="Emily" info="Beleza">
                            <Avatar src={"default-user-icon.svg"} />
                        </Conversation>
                        <Conversation className="regular-conversation" key={0} name={"João"} lastSenderName="Carlos" info="Pode pagar">
                            <Avatar src={"default-user-icon.svg"} />
                        </Conversation>
                        <Conversation className="regular-conversation" key={0} name={"Maria"} lastSenderName="Carlos" info="Cadê o projeto?">
                            <Avatar src={"default-user-icon.svg"} />
                        </Conversation>
                    </ConversationList>
                </Sidebar>
                <ChatContainerStyled>
                    <ConversationHeader>
                        <Avatar src={"default-user-icon.svg"} name="Emily" />
                        <ConversationHeader.Content userName="Emily" info="Freelancer" />
                    </ConversationHeader>
                    <MessageList className="message-list">
                        <MessageSeparator>
                            Quinta-Feira, 12 de Maio de 2022
                        </MessageSeparator>
                        <Message key={0} model={{
                            message: "Oi",
                            sentTime: "22:00",
                            direction: "outgoing",
                            position: "single"
                        }} />
                        <MessageSeparator>
                            Sexta-Feira, 13 de Maio de 2022
                        </MessageSeparator>
                        <Message key={1} model={{
                            message: "Olá",
                            sentTime: "10:32",
                            direction: "incoming",
                            position: "single"
                        }} />
                        <Message key={2} model={{
                            message: "Tudo bem?",
                            sentTime: "10:32",
                            direction: "incoming",
                            position: "single"
                        }} />
                        <Message key={3} model={{
                            message: "Sim, e você",
                            sentTime: "10:35",
                            direction: "outgoing",
                            position: "single"
                        }} />
                        <Message key={4} model={{
                            message: "Preciso que você me envie a proposta do projeto",
                            sentTime: "10:37",
                            direction: "outgoing",
                            position: "single"
                        }} />
                        <Message key={5} model={{
                            message: "Beleza",
                            sentTime: "10:32",
                            direction: "incoming",
                            position: "single"
                        }} />
                    </MessageList>
                    <MessageInput attachButton={false} placeholder="Digite sua mensagem..." />
                </ChatContainerStyled>
            </Container>
        </ChatStyle>
        <Footer />
    </div>;

}

export default Chat;