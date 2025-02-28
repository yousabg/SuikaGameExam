using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    public float clicksSinceSpawn = 0f;
    private GameObject claw;
    private ClawMove cm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        claw = GameObject.Find("Claw_0");
        cm = claw.GetComponent<ClawMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicksSinceSpawn++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            CandyBehaviour otherCandyBehaviour = collision.gameObject.GetComponent<CandyBehaviour>();
            if (clicksSinceSpawn > otherCandyBehaviour.clicksSinceSpawn)
            {
                Vector3 spawnPos = (transform.position + collision.gameObject.transform.position) / 2;
                GameObject newBallVariant = cm.mergeBall(gameObject, spawnPos);
                if (newBallVariant != null)
                {
                    Destroy(collision.gameObject);
                    GameObject newBall = Instantiate(newBallVariant, spawnPos, Quaternion.identity);
                    Destroy(gameObject);
                }
                
            }
        }
    }
}
