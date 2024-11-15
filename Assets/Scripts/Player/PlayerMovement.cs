using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float radius = 5f;          
    public float angularSpeed = 2f;     
    private float angle = 0f;          
    private int direction = 1;

    void Update()
    {
    
        angle += direction * angularSpeed * Time.deltaTime;

   
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;

        transform.position = new Vector3(x, y, transform.position.z);

  
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction *= -1;
        }
    }
}
