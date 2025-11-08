using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{

    public string startScene;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene(startScene);
            //FadeScreen.instance.FadeFromBlack();
        }
    }

}
