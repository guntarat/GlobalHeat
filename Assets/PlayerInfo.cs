using Unity.Netcode;
using UnityEngine;

public class PlayerInfo : NetworkBehaviour
{
    public string playerName;

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            SetPlayerNameServerRpc(LobbyManager.PlayerName);
        }
    }

    [ServerRpc]
    void SetPlayerNameServerRpc(string name)
    {
        playerName = name;
        Debug.Log($"Player name set to: {playerName}");
    }
}
