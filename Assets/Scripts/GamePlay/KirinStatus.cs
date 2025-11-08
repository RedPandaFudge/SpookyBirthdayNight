using UnityEngine;
using UnityEngine.InputSystem;

public class KirinStatus : MonoBehaviour
{
    private bool ifPlayerCollides;
    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    [SerializeField]
    private IntSO herbalCount;
    public static bool getHerbal;
    public static bool lightOn;
    public GameObject KirinEyes;
    public GameObject hintSign;


    InputAction interactAction;



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");
        if (lightOn)
        {
            Destroy(KirinEyes);
            Destroy(GetComponent<NPCHints>());
            Destroy(hintSign);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lightOn = KirinLightSwitch.lightOn;
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame() && lightOn && !getHerbal)
        {
            HerbalAnim.instance.getHerbal = true;
            AudioManager.instance.PlaySFX(6);
            herbalCount.Value += 1;
            getHerbal = true;
        }
        if (lightOn)
        {
            Destroy(KirinEyes);
            Destroy(GetComponent<NPCHints>());
            Destroy(hintSign);
        }
    }
}
