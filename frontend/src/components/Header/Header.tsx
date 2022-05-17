import { Badge, Box, Button, Drawer, List, ListItem, ListItemText, Menu, MenuItem } from "@material-ui/core";
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
    const [freelancer, setFreelancer] = useGlobalState('freelancer');
    const [notifications, setNotifications] = React.useState(2);

    const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
    const open = Boolean(anchorEl);
    const handleMenuClick = (event: React.MouseEvent<HTMLButtonElement>) => {
        setAnchorEl(event.currentTarget);
    };

    let navigate = useNavigate();

    const handleMenuClose = (ref: string) => {
        setAnchorEl(null);
        if (ref.length > 0) {
            return navigate("../" + ref);
        }
    };

    return (
        <StyledHeader>
            <MenuIcon>
                <StyledMenuButton
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
                                <ListItemButton onClick={() => handleMenuClose("jobs-list")} >
                                    <ListItemText primary="Jobs" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={() => handleMenuClose("create-job")} >
                                    <ListItemText primary="Iniciar um novo job"/>
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={() => handleMenuClose("chat")} >
                                    <ListItemText primary="Chat"/>
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={() => handleMenuClose("")}>
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
                <SubTitle>
                    {freelancer ? "Freelancer" : "Cliente"}
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