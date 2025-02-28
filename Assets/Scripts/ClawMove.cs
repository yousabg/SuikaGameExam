using UnityEngine;

public class ClawMove : MonoBehaviour
{
    Camera cam;
    public Vector3 mousePosG;
    public float spawnY;
    public float minX;
    public float maxX;
    public GameObject candyPrefab;
    public float candyX;
    public float candyY;
    public GameObject currentCandy;
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
            if (currentCandy == null)
            {
                currentCandy = Instantiate(candyPrefab, new Vector3(candyX, candyY, 0), Quaternion.identity);
                Rigidbody2D rb = currentCandy.GetComponent<Rigidbody2D>();
                rb.gravityScale = 0f;
            }
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
}
