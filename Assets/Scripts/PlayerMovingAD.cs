using UnityEngine;

public class PlayerMovingAD : MonoBehaviour
{
    public float speed;
    public float min;
    public float max;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x - speed;
            if (newPosition.x > min)
            {
                transform.position = newPosition;
            }
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x + speed;
            if (newPosition.x < max)
            {
                transform.position = newPosition;
            }
        }
        
    }
}
