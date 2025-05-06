using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : NetworkBehaviour
{
    public Slider healthSlider;
    private PlayerHealth2D playerHealth;

    void Start()
    {
        if (!IsOwner)
        {
            gameObject.SetActive(false);
            return;
        }

        playerHealth = GetComponent<PlayerHealth2D>();
        healthSlider.maxValue = playerHealth.maxHealth;
    }

    void Update()
    {
        if (IsOwner && playerHealth != null)
        {
            healthSlider.value = playerHealth.GetCurrentHealth();
        }
    }
}
