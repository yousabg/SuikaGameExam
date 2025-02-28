using UnityEngine;
using TMPro;

public class ClawMove : MonoBehaviour
{
    Camera cam;
    public Vector3 mousePosG;
    public float spawnY;
    public float minX;
    public float maxX;
    public GameObject candyPrefab;
    public float candyY;
    private float candiesSpawned = 0f;
    public TextMeshProUGUI candyCounter;
    public GameObject[] ballVariants;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Instantiate(candyPrefab, new Vector3(mousePosG.x, candyY, 0), Quaternion.identity);
            candiesSpawned++;
            candyCounter.SetText(candiesSpawned + " candies spawned");
        }
    }

    private void FixedUpdate()
    {
        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosG.x >= minX && mousePosG.x <= maxX)
        {
            transform.position = new Vector3(mousePosG.x, spawnY, transform.position.z);
        }
    }

    public GameObject mergeBall(GameObject ball, Vector3 spawnPos)
    {
        for (int i = 0; i < ballVariants.Length; i++)
        {
            if (ball.CompareTag(ballVariants[i].tag))
            {
                if (i < ballVariants.Length-1)
                {
                    return ballVariants[i + 1];
                }
            }
        }
        return null;
    }
}
