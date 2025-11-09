using UnityEngine;
using UnityEngine.InputSystem;

public class TitlePage : MonoBehaviour
{

    
    public string startScene;
    [SerializeField]
    private StringSO objNameSO;
    [SerializeField]
    private IntSO herbalCount;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // Initialize the SO values
        objNameSO.Value = null;
        herbalCount.Value = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.anyKey.wasPressedThisFrame)
        {
            Vector3 playerPos = new Vector3(0f, - 2.376502f, 0f);
            LevelManager.instance.SwitchScene(startScene, playerPos);
        }
    }

}
