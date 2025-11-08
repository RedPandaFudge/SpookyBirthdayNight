using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

[DefaultExecutionOrder(-100)]

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    //public HoldingStatus holdingStatus;

    [SerializeField]
    private StringSO objNameSO;
    [SerializeField]
    private IntSO herbalCount;
    private GameObject player;
    private Transform itemHoldingRoot;
    private Vector3 playerPos;

    void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject); // <- this is the persistence switch
    }


    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;


    void Update()
    {
        /*switchToPot = false;
        if(herbalCount.Value == 3 && !switchToPot)
        {
            //Scene herbalCollected = SceneManager.GetSceneByName("锅");
            string herbalCollected = "锅";
            switchToPot = true;
            SwitchScene(herbalCollected);
        }
        */
    }


    public void SwitchScene(string levelToLoad, Vector3 Pos)
    {
        playerPos = Pos;
        PickablesManagement.Instance.RecordPickables();
        StartCoroutine(SwitchSceneCo(levelToLoad));
    }

    public IEnumerator SwitchSceneCo(string levelToLoad)
    {
        FadeScreen.instance.FadeToBlack();
        yield return new WaitForSeconds(1f / FadeScreen.instance.fadeSpeed);

        var op = SceneManager.LoadSceneAsync(levelToLoad, LoadSceneMode.Single);
        while (!op.isDone) yield return null;

    }

    private void OnSceneLoaded(Scene s, LoadSceneMode m)
    {
        // Player persists; it already exists right now.
        PickablesManagement.Instance.DetectPickables(s.name);
        CheckStatus();
        player.transform.position = playerPos;
        Debug.Log("Player pos switched");
    }

    public void CheckStatus()
    {
        player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            itemHoldingRoot = player.transform.Find("ItemHolding");
            HideAllSigns();
            if (objNameSO.Value != null)
            {
                //Debug.Log("Object found:" + objNameSO.Value);
                ShowHoldingSign();
            }
        }


    }


    private void ShowHoldingSign()
    {
        // 4) Enable the matching Holding_ sprite
        var Sign = itemHoldingRoot.Find("Holding_" + objNameSO.Value);
        if (Sign != null)
        {
            var holdSprite = Sign.GetComponent<SpriteRenderer>();
            if (holdSprite != null) holdSprite.enabled = true;
            //Debug.Log("Sign displayed:" + Sign);

        }
    }

    private void HideAllSigns()
    {
        var allHolding = itemHoldingRoot.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var sr in allHolding)
        {
            sr.enabled = false;

        }
        //Debug.Log("All signs hidden.");
    }


}
