using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkUI : MonoBehaviour
{
    public string gameSceneName = "CaveMap";

    public void StartAsClient()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void StartAsHost()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene("CaveMap", LoadSceneMode.Single);

    }

    public void StartAsServer()
    {
        NetworkManager.Singleton.StartServer();
        NetworkManager.Singleton.SceneManager.LoadScene("CaveMap", LoadSceneMode.Single);

    }
}
