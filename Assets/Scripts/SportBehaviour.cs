using UnityEngine;

public class SportBehaviour : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;
    public GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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