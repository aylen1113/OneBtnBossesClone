using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerPowerup : MonoBehaviour
{
    [Header("Configuración Power-up")]
    public float maxCharger = 100f;
    private float currentCharger;

    public float speedMultiplier = 2f;
    public float rechargeRate = 10f;
    public float drainRate = 20f;

    [Header("Referencias")]
    public Slider chargerSlider;
    public Rigidbody2D rb;

    private bool isPowerUpActive = false;
    private bool powerButtonHeld = false;

    private PlayerMov controls;

    private void Awake()
    {
        controls = new PlayerMov();

        controls.Player.PowerUp.started += ctx => powerButtonHeld = true;
        controls.Player.PowerUp.canceled += ctx => powerButtonHeld = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        currentCharger = maxCharger;

        chargerSlider.maxValue = maxCharger;
        chargerSlider.value = currentCharger;
    }

    void Update()
    {
        if (powerButtonHeld && currentCharger > 0)
        {
            ActivatePowerUp();
            ConsumeCharger();
        }
        else
        {
            DeactivatePowerUp();
            RechargeCharger();
        }

        chargerSlider.value = currentCharger;
    }

    void ActivatePowerUp()
    {
        if (!isPowerUpActive)
        {
            isPowerUpActive = true;
            rb.velocity *= speedMultiplier;
        }
    }

    void DeactivatePowerUp()
    {
        if (isPowerUpActive)
        {
            isPowerUpActive = false;
            rb.velocity /= speedMultiplier;
        }
    }

    void ConsumeCharger()
    {
        currentCharger -= drainRate * Time.deltaTime;

        if (currentCharger <= 0)
        {
            currentCharger = 0;
            DeactivatePowerUp();
        }
    }

    void RechargeCharger()
    {
        if (!isPowerUpActive && currentCharger < maxCharger)
        {
            currentCharger += rechargeRate * Time.deltaTime;

            if (currentCharger > maxCharger)
                currentCharger = maxCharger;
        }
    }
}