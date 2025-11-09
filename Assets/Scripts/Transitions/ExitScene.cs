using UnityEngine;

public class ExitScene : MonoBehaviour
{
    public static ExitScene instance;
    public string levelToLoad;
    public Vector3 playerPos;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            LevelManager.instance.SwitchScene(levelToLoad, playerPos);
        }
    }
}
