using UnityEngine;

public class PlayerMovingAD : MonoBehaviour
{
    public float speed;
    public GameObject sport;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (sport != null)
        {
            Vector3 sportOffset = new Vector3(0f, -1f, 0f);
            sport.transform.position = transform.position + sportOffset;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            sport = null;
        }
        {
            if (Input.GetKey(KeyCode.A))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x - speed;
                transform.position = newPosition;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x + speed;
                transform.position = newPosition;
            }
        }
    }
}
