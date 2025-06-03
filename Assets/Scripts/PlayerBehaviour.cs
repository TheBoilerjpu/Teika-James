using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


    public float speed;
    public GameObject sport;
    public GameObject currentSport;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sport != null)
        {
            Vector3 sportOffset = new Vector3(0f, -1f, 0f);
            sport.transform.position = transform.position + sportOffset;
            sport.GetComponent<PolygonCollider2D>().enabled = false;
            sport.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sport.GetComponent<PolygonCollider2D>().enabled = true;
            sport.GetComponent<Rigidbody2D>().gravityScale = 1f;
            sport = null;
        }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x - speed;
                transform.position = newPosition;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Vector3 newPosition = transform.position;
                newPosition.x = newPosition.x + speed;
                transform.position = newPosition;
            }
        
    }
}