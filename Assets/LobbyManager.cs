using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public InputField nameInput;
    public Button startButton;

    public static string PlayerName; 

    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
    }

    void OnStartClicked()
    {
        if (!string.IsNullOrEmpty(nameInput.text))
        {
            PlayerName = nameInput.text;
            SceneManager.LoadScene("CaveMap"); 
        }
    }
}
