using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    public Vector3 mousePosG;
    Camera cam;
    public float minX;
    public float maxX;
    public float spawnY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
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
