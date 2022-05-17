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

export function Header() {
    const [freelancer, setFreelancer] = React.useState(false);
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
                        onClick={handleMenuClose}
                        onKeyDown={handleMenuClose}
                    >
                        <List>
                            <ListItem>
                                <ListItemButton onClick={handleMenuClose}>
                                    <ListItemText primary="Jobs" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={handleMenuClose}>
                                    <ListItemText primary="Iniciar um novo job" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={handleMenuClose}>
                                    <ListItemText primary="Chat" />
                                </ListItemButton>
                            </ListItem>
                            <ListItem>
                                <ListItemButton onClick={handleMenuClose}>
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
                <Button style={{ padding: "0 !important" }}>
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