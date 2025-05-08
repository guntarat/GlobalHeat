using TMPro;
using UnityEngine;

public class RelayUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI joinCodeText;

    private void Start()
    {
        // Retrieve the join code from PlayerPrefs
        string joinCode = PlayerPrefs.GetString("JoinCode", "No Join Code"); // Default value if not found
        SetJoinCode(joinCode);
    }

    public void SetJoinCode(string code)
    {
        joinCodeText.text = $"Join Code: {code}"; // Display the join code
    }
}
