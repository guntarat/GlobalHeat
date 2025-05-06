using TMPro;
using Unity.Netcode;
using UnityEngine;

public class PlayerNameDisplay : NetworkBehaviour
{
    [SerializeField] private TextMeshProUGUI nameLabel;

    private NetworkVariable<string> playerName = new NetworkVariable<string>(writePerm: NetworkVariableWritePermission.Server);

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            SetNameServerRpc(LobbyManager.PlayerName);
        }

        playerName.OnValueChanged += OnNameChanged;
        nameLabel.text = playerName.Value;
    }

    private void OnNameChanged(string oldName, string newName)
    {
        nameLabel.text = newName;
    }

    [ServerRpc]
    void SetNameServerRpc(string name)
    {
        playerName.Value = name;
    }
}
