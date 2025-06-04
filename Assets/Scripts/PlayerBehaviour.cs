using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{


    public float speed;
    public GameObject[] sports;
    public GameObject currentSport;
    public float min;
    public float max;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentSport != null)
        {
            Vector3 sportOffset = new Vector3(0f, -1f, 0f);
            currentSport.transform.position = transform.position + sportOffset;
            //currentSport.GetComponent<PolygonCollider2D>().enabled = false;
            currentSport.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            int index = Random.Range(0, sports.Length);
            currentSport = Instantiate(sports[index], transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSport.GetComponent<PolygonCollider2D>().enabled = true;
            currentSport.GetComponent<Rigidbody2D>().gravityScale = 1f;
            currentSport = null;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed;
            if (newPosition.x > min)
            {
                transform.position = newPosition;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
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