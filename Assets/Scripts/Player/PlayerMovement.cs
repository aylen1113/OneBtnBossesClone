using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float radius = 5f;
    public float angularSpeed = 2f;

    private float angle = 0f;
    private int direction = 1;

    private PlayerMov controls;

    private void Awake()
    {
        controls = new PlayerMov();

        controls.Player.PowerUp.performed += ctx =>
        {
            direction *= -1;
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        angle += direction * angularSpeed * Time.deltaTime;

        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
