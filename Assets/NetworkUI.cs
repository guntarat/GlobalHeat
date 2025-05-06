using Unity.Netcode;
using UnityEngine;

public class NetworkUI : MonoBehaviour
{
    public void StartAsClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void StartAsHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StartAsServer()
    {
        NetworkManager.Singleton.StartServer();
    }
}
