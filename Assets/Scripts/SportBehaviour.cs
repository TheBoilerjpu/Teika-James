using UnityEngine;

public class SportBehaviour : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public float timeThusFar;
    public GameObject gmeOver;

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
        Debug.Log("You entered the trigger of:" + collision.gameObject.name);
        timeStart = Time.time; //Get current Time
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Trigger Stay on:" + collision.gameObject.name);
        timeThusFar = Time.time - timeStart;
        Debug.Log("Game over Timer updated: " + timeThusFar);
        if (timeThusFar >= timeout)
        {
            Debug.Log("Game over");
        }
    }
}