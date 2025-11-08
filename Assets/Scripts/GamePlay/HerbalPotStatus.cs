using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HerbalPotStatus : MonoBehaviour
{
    [SerializeField]
    private IntSO herbalCount;
    public string startScene;
    public string endScene;
    public static bool flashOn;
    private static bool goEnd;


    void Awake()
    {

        goEnd = false;
        flashOn = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            if (goEnd)
            {
                AudioSource BGM = AudioManager.instance.Bgm;
                BGM.Stop();
                SceneManager.LoadScene(endScene);
                AudioSource Ending = AudioManager.instance.Ending;
                Ending.Play();
                

                
            }
            else if (herbalCount.Value == 3 && !goEnd)
            {
                AudioManager.instance.PlaySFX(8);
                flashOn = true;
                goEnd = true;
            }
            else
            {
                Vector3 playerPos = new Vector3(0.77f, -2.3765f, 0f);
                LevelManager.instance.SwitchScene(startScene, playerPos);
            }

        } 
    }

}
