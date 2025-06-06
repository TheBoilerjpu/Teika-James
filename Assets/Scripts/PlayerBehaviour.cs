using UnityEngine;
using TMPro;
public class PlayerBehaviour : MonoBehaviour
{


    public float speed;
    public GameObject[] sports;
    public GameObject currentSport;
    public float min;
    public float max;
    public GameObject gameOverT;

    public int[] points;
    public int score;
    public TMP_Text scoreText;
    private float timer;
    public float timerThreshold;
    public AudioSource dropSound;
    public AudioSource mergeSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        timer = 0;
        dropSound = GetComponents<AudioSource>()[0];
        mergeSound = GetComponents<AudioSource>()[1];
    }
    public void PlayMerge()
    {
        mergeSound.Play();
    }
    public void UpdateScore(int sportType)
    {
        score = score + points[sportType];
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverT.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
            if (currentSport != null)
        {
            Vector3 sportOffset = new Vector3(0f, -1f, 0f);
            currentSport.transform.position = transform.position + sportOffset;
            //currentSport.GetComponent<PolygonCollider2D>().enabled = false;
            currentSport.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        else
        {
            int index = Random.Range(0, 5);
            currentSport = Instantiate(sports[index], transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Space)&& (timer >= timerThreshold))
        {
            dropSound.Play();
            timer = 0;
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
