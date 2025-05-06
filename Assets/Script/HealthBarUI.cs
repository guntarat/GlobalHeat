using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class HealthBarUI : MonoBehaviour
{
    public Image fillImage;
    private PlayerHealth2D playerHealth;

    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth2D>();
    }

    void Update()
    {
        if (playerHealth != null && fillImage != null)
        {
            float fillAmount = (float)playerHealth.GetCurrentHealth() / playerHealth.maxHealth;
            fillImage.fillAmount = fillAmount;
        }
    }
}
