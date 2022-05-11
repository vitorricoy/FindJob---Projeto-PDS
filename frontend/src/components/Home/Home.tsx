import { Badge, Button, Menu, MenuItem } from "@material-ui/core";
import NotificationsIcon from '@mui/icons-material/Notifications';
import React from "react";
import { 
    Body,
    Buttons,
    Container,
    Footer,
    Header,
    HeaderTitle,
    MenuIcon,
    MenuIconSvg,
    MenuIconSvgPath,
    NotificationIcon,
    StyledButton,
    StyledMenuButton,
    SubTitle,
    Title,
} from "./styles";

export function Home () {
    const [freelancer, setFreelancer] = React.useState(true);
    const [notifications, setNotifications] = React.useState(2);

    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleMenuClick = (event: React.MouseEvent<HTMLButtonElement>) => {
      setAnchorEl(event.currentTarget);
    };
    const handleMenuClose = () => {
      setAnchorEl(null);
    };
    
    return (
        <Container>
            <Header>
                <MenuIcon>
                    <StyledMenuButton
                        id="basic-button"
                        aria-controls={open ? 'basic-menu' : undefined}
                        aria-haspopup="true"
                        aria-expanded={open ? 'true' : undefined}
                        onClick={handleMenuClick}
                    >
                        <MenuIconSvg viewBox="0 0 19 20" width="48" height="48">
                            <MenuIconSvgPath />
                        </MenuIconSvg>
                    </StyledMenuButton>

                    <Menu
                        id="basic-menu"
                        anchorEl={anchorEl}
                        open={open}
                        onClose={handleMenuClose}
                        MenuListProps={{
                            'aria-labelledby': 'basic-button',
                        }}
                        anchorOrigin={{
                            vertical: 'bottom',
                            horizontal: 'center',
                          }}
                          transformOrigin={{
                            vertical: 'top',
                            horizontal: 'center',
                          }}
                    >
                        <MenuItem onClick={handleMenuClose}>Jobs</MenuItem>
                        <MenuItem onClick={handleMenuClose}>Iniciar um novo job</MenuItem>
                        <MenuItem onClick={handleMenuClose}>Chat</MenuItem>
                        <MenuItem onClick={handleMenuClose}>Logout</MenuItem>
                    </Menu>
                </MenuIcon>

                <HeaderTitle>
                    <Title>
                        FindJob 
                    </Title>
                    <SubTitle>
                        {freelancer? "Freelancer": "Cliente"}
                    </SubTitle>
                </HeaderTitle>

                <NotificationIcon>
                    <Button style={{padding: "0 !important"}}>
                        <Badge 
                            badgeContent={notifications} 
                            color="primary"
                        >
                            <NotificationsIcon color="action" />
                        </Badge>
                    </Button>
                </NotificationIcon>
            </Header>

            <Body>
                <img draggable="false" src="https://i.imgur.com/auZepyp.jpg" alt="Workhome Login" width='100%' height='100%'/>
                <div className="up-bottom-left">Encontre</div>
                {freelancer? 
                    <div className="bottom-left">Trabalhos para colocar em prática suas habilidades</div>
                    :
                    <div className="bottom-left">Profissionais qualificados para qualquer tarefa</div>}
            </Body>

            <Buttons>
                <div style={{alignSelf: "center"}}>
                    <StyledButton variant="contained"> {freelancer? "Buscar jobs": "Novo job"} </StyledButton>
                </div>
                
                <div style={{alignSelf: "center"}}>
                    <StyledButton variant="contained"> Meus jobs </StyledButton>
                </div>
            </Buttons>

            <Footer>
                <div style={{paddingBlock: "6px 4px"}}>Belo Horizonte. {new Date(Date.now()).toString()}</div>
                <div> © 2022 FindJob. Todos os direitos reservados. </div>
            </Footer>
        </Container>
    );
}