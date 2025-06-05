using UnityEngine;

public class SportBehaviour : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;
    public GameObject[] sports;
    public int sportType;
    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeStart = Time.time; //Get current Time
        sports = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().sports;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherSport = collision.gameObject;
        if (otherSport.CompareTag("Sport"))
        {
            int otherSportType = otherSport.GetComponent<SportBehaviour>().sportType;
            Debug.Log("You collided with a " + otherSportType);
            if (sportType == otherSportType && sportType != 10)
            {
                if (transform.position.x > otherSport.transform.position.x ||
                    (transform.position.y > otherSport.transform.position.y
                    && transform.position.x == otherSport.transform.position.x))
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().UpdateScore(sportType);
                    GameObject newSport =
                        Instantiate(sports[sportType + 1], Vector3.Lerp(transform.position,
                       otherSport.transform.position, 0.5f), Quaternion.identity);
                    newSport.GetComponent<Collider2D>().enabled = true;
                    newSport.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    Destroy(otherSport);
                    Destroy(gameObject);
                }
            }
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        Debug.Log("You entered the trigger of:" + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Top"))
        {
            Debug.Log("Game over Timer started at: " + timeStart);
            timeStart = Time.time; //Get current Time
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;
        Debug.Log("Trigger Stay on:" + collision.gameObject.tag);
        if (tag.Equals("Top"))
        {
            timeThusFar = Time.time - timeStart;
            Debug.Log("Game over Timer updated: " + timeThusFar);
            if (timeThusFar >= timeout)
            {
                //Debug.Log("Game over");
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>().GameOver();
            }
        }
    }
}