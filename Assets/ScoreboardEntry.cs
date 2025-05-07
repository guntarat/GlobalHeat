using TMPro;
using UnityEngine;

public class ScoreboardEntry : MonoBehaviour
{
    public TMP_Text playerNameText;
    public TMP_Text killCountText;

    private PlayerStats trackedStats;

    public void Initialize(PlayerStats stats)
    {
        trackedStats = stats;
        playerNameText.text = stats.PlayerName.Value.ToString();
        killCountText.text = stats.KillCount.Value.ToString();

        stats.KillCount.OnValueChanged += OnKillCountChanged;
    }

    private void OnKillCountChanged(int oldVal, int newVal)
    {
        killCountText.text = newVal.ToString();
    }

    private void OnDestroy()
    {
        if (trackedStats != null)
        {
            trackedStats.KillCount.OnValueChanged -= OnKillCountChanged;
        }
    }
}
