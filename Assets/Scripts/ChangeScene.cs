using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gotoGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("gameplay");
    }
}
