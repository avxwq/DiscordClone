import { useEffect, useRef, useState } from "react";
import * as signalR from "@microsoft/signalr";

const SIGNALR_SERVER = "http://localhost:5000/VoiceChatHub";
const ICE_SERVERS: RTCConfiguration = {
    iceServers: [] // Brak STUN/TURN – dzia³a tylko w LAN
};

export function usePrivateVoiceChat(userId: string) {
    const [isConnected, setIsConnected] = useState(false);
    const [incomingCall, setIncomingCall] = useState<string | null>(null);
    const peerConnection = useRef(new RTCPeerConnection(ICE_SERVERS));
    const connection = useRef<signalR.HubConnection | null>(null);
    const localStream = useRef<MediaStream | null>(null);

    useEffect(() => {
        connection.current = new signalR.HubConnectionBuilder()
            .withUrl(SIGNALR_SERVER)
            .withAutomaticReconnect()
            .build();

        connection.current.on("IncomingCall", (callerId) => {
            setIncomingCall(callerId);
        });

        connection.current.on("CallAccepted", async (calleeConnectionId) => {
            localStream.current = await navigator.mediaDevices.getUserMedia({ audio: true });
            localStream.current.getTracks().forEach(track => peerConnection.current.addTrack(track));

            const offer = await peerConnection.current.createOffer();
            await peerConnection.current.setLocalDescription(offer);
            connection.current?.send("SendOffer", calleeConnectionId, offer);
        });

        connection.current.on("ReceiveOffer", async (callerConnectionId, offer) => {
            await peerConnection.current.setRemoteDescription(new RTCSessionDescription(offer));

            const answer = await peerConnection.current.createAnswer();
            await peerConnection.current.setLocalDescription(answer);
            connection.current?.send("SendAnswer", callerConnectionId, answer);
        });

        connection.current.on("ReceiveAnswer", async (answer) => {
            await peerConnection.current.setRemoteDescription(new RTCSessionDescription(answer));
        });

        connection.current.on("ReceiveIceCandidate", async (candidate) => {
            await peerConnection.current.addIceCandidate(new RTCIceCandidate(JSON.parse(candidate)));
        });

        connection.current.start().then(() => {
            connection.current?.send("RegisterUser", userId);
            setIsConnected(true);
        });

        return () => {
            connection.current?.stop();
        };
    }, [userId]);

    async function callUser(targetUserId: string) {
        connection.current?.send("CallUser", targetUserId);
    }

    async function acceptCall() {
        if (!incomingCall) return;
        connection.current?.send("AcceptCall", incomingCall);
        setIncomingCall(null);
    }

    async function rejectCall() {
        if (!incomingCall) return;
        connection.current?.send("RejectCall", incomingCall);
        setIncomingCall(null);
    }

    return { isConnected, incomingCall, callUser, acceptCall, rejectCall };
}
