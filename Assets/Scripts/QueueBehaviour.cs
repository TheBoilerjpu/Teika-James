using UnityEngine;
public class QueueBehaviour : MonoBehaviour
{
    public Sprite[] UISprites;
    public int[] queuedSports;
    private SpriteRenderer[] queueItems;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        queueItems = new SpriteRenderer[4];
        queuedSports = new int[4];

        for (int i = 0; i < transform.childCount; i++)
        {
            queueItems[i] = transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
        }

        for (int i = 0; i < 4; i++)
        {
            queuedSports[i] = Random.Range(0, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            queueItems[i].sprite = UISprites[queuedSports[i]];
        }
    }
    public void UpdateQueue()
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != 3)
            {
                queuedSports[i] = queuedSports[i + 1];
            }
            else
            {
                queuedSports[3] = Random.Range(0, 5);
            }
        }
    }
}