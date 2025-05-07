using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerStats : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> PlayerName = new();
    public NetworkVariable<int> KillCount = new();

    public void AddKill()
    {
        if (IsServer)
            KillCount.Value++;
    }
}
