import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { useStore } from "../../../app/stores/store";
import { Box, Typography, Divider, Button, Dialog, DialogActions, DialogTitle } from "@mui/material";
import { Outlet, useNavigate } from "react-router-dom";
import { usePrivateVoiceChat } from "../hooks/usePrivateVoiceChat";

export default observer(function ChannelDashboard() {
    const { userStore, friendStore } = useStore();
    const navigate = useNavigate();
    const { callUser, incomingCall, acceptCall, rejectCall } = usePrivateVoiceChat(userStore.user!.id);

    useEffect(() => {
        const loadFriends = async () => {
            friendStore.setFriends(await friendStore.GetUserFriendsById(userStore.user!.id));
        }
        loadFriends();
    }, [friendStore, userStore]);

    const handleClick = (friendId: string) => {
        navigate('/main/friend/' + friendId);
    }

    const handleCallClick = (friendId: string) => {
        callUser(friendId);
    }

    return (
        <Box display="flex" flexDirection="row" height="91vh" width="1474px" sx={{ backgroundColor: "#4E4E4E" }}>
            <Box
                display="flex"
                flexDirection="column"
                alignItems="center"
                mt="20px"
                sx={{
                    backgroundColor: "#4E4E4E",
                    width: "250px",
                    flexShrink: 0,
                }}
            >
                <Typography variant="h6">Friends</Typography>
                <Divider sx={{ width: '80%', borderColor: 'gray', my: 1 }} />
                {friendStore.friends ? (
                    friendStore.friends.map((friend) => (
                        <Box
                            key={friend.id}
                            display="flex"
                            gap="10px"
                            p="10px"
                            alignItems="center"
                            width="85%"
                            height="50px"
                            sx={{
                                backgroundColor: "#222222",
                                borderRadius: "15px",
                                mb: "10px",
                                '&:hover': {
                                    backgroundColor: "#2A2A2A",
                                    cursor: "pointer",
                                },
                            }}
                        >
                            <Box display="flex" flexDirection="row" alignItems="center" width="100%">
                                <Box
                                    display="flex"
                                    width="40px"
                                    height="40px"
                                    sx={{
                                        borderRadius: "50%",
                                        backgroundImage: friend.image ? `url(${friend.image})` : `url(/user.png)`,
                                        backgroundSize: "cover",
                                        backgroundPosition: "center",
                                    }}
                                    onClick={() => handleClick(friend.id)}
                                />
                                <Typography variant="body1" sx={{ ml: 2 }} onClick={() => handleClick(friend.id)}>
                                    {friend.username}
                                </Typography>
                                <Button
                                    variant="contained"
                                    color="primary"
                                    size="small"
                                    sx={{ ml: "auto" }}
                                    onClick={() => handleCallClick(friend.id)}
                                >
                                    Call
                                </Button>
                            </Box>
                        </Box>
                    ))
                ) : (
                    <Box display="flex" justifyContent="center" alignItems="center" mt="20px">
                        <Typography variant="body1">No friends :(</Typography>
                    </Box>
                )}
            </Box>

            <Box display="flex" sx={{ flexGrow: 1, backgroundColor: "#060018", height: "100%" }}>
                <Outlet />
            </Box>

            {/* Dialog do obs³ugi po³¹czeñ */}
            <Dialog open={Boolean(incomingCall)} onClose={() => rejectCall(incomingCall!)}>
                <DialogTitle>{incomingCall ? `Incoming call from ${incomingCall}` : ""}</DialogTitle>
                <DialogActions>
                    <Button onClick={() => acceptCall(incomingCall!)} color="primary">Accept</Button>
                    <Button onClick={() => rejectCall(incomingCall!)} color="secondary">Reject</Button>
                </DialogActions>
            </Dialog>
        </Box>
    );
});
