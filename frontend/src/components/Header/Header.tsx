import { Badge, Button, Menu, MenuItem } from "@material-ui/core";
import NotificationsIcon from '@mui/icons-material/Notifications';
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