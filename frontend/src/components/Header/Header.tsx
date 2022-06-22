import { Badge, Box, Button, Drawer, List, ListItem, ListItemText } from "@material-ui/core";
import NotificationsIcon from '@mui/icons-material/Notifications';
import { ListItemButton } from "@mui/material";
import React from "react";
import {
    HeaderTitle,
    MenuIcon,
    MenuIconSvg,
    MenuIconSvgPath,
    NotificationIcon,
    StyledHeader,
    StyledMenuButton,
    SubTitle,
    Title,
} from "./styles"
import { useNavigate } from "react-router-dom";
import { useGlobalState } from "../..";

export function Header() {
    const [currentUser] = useGlobalState('currentUser');
    const [notifications] = React.useState(0);

    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleMenuClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };

    let navigate = useNavigate();

    const handleMenuClose = (ref: string) => {
        setAnchorEl(null);
        if (ref.length > 0) {
            if (ref === "logout") {
                return navigate("../");
            }
            return navigate("../" + ref);
        }
    };

    return (
        <StyledHeader>
            <MenuIcon>
                <StyledMenuButton
                    data-testid="menu-button"
                    id="basic-button"
                    aria-controls={open ? 'basic-menu' : undefined}
                    aria-haspopup="true"
                    aria-expanded={open ? 'true' : undefined}
                    onClick={handleMenuClick}
                >
                    <MenuIconSvg viewBox="-7 -3.5 35 35">
                        <MenuIconSvgPath />
                    </MenuIconSvg>
                </StyledMenuButton>
                <Drawer
                    anchor="left"
                    open={open}
                    onClose={handleMenuClose}
                >
                    <Box
                        role="presentation"
                        onClick={() => handleMenuClose("")}
                        onKeyDown={() => handleMenuClose("")}
                    >
                        <List>
                            <ListItem>
                                <ListItemButton onClick={() => handleMenuClose("home")}>
                                    <ListItemText primary="Home" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton data-testid="jobslist-button" onClick={() => handleMenuClose("jobs-list/false")} >
                                    <ListItemText primary="Jobs" />
                                </ListItemButton>
                            </ListItem>
                            {!currentUser.isFreelancer ?
                                <ListItem>
                                    <ListItemButton onClick={() => handleMenuClose("create-job")} >
                                        <ListItemText primary="Iniciar um novo job" />
                                    </ListItemButton>
                                </ListItem>
                                :
                                null}
                            <ListItem>
                                <ListItemButton onClick={() => handleMenuClose("chat")} >
                                    <ListItemText primary="Chat" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton data-testid="logout-button" onClick={() => handleMenuClose("logout")}>
                                    <ListItemText primary="Logout" />
                                </ListItemButton>
                            </ListItem>
                        </List>
                    </Box>
                </Drawer>
            </MenuIcon>

            <HeaderTitle>
                <Title>
                    FindJob
                </Title>
                <SubTitle data-testid="subtitle-div">
                    {currentUser.isFreelancer ? "Freelancer" : "Cliente"}
                </SubTitle>
            </HeaderTitle>

            <NotificationIcon>
                <Button style={{ padding: "0 !important" }} href="./chat">
                    <Badge
                        badgeContent={notifications}
                        color="primary"
                    >
                        <NotificationsIcon color="action" />
                    </Badge>
                </Button>
            </NotificationIcon>
        </StyledHeader>
    )
}