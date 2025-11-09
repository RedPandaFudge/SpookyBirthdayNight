using UnityEngine;
using UnityEngine.InputSystem;

public class HaineStatus : MonoBehaviour
{
    private bool ifPlayerCollides;
    private SpriteRenderer spriteRenderer;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;


    [SerializeField]
    private StringSO objNameSO;
    [SerializeField]
    private IntSO herbalCount;

    InputAction interactAction;
    public Sprite newStatus;
    public static bool statusChanged;

    void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (statusChanged)
        {
            spriteRenderer.sprite = newStatus;
            Destroy(GetComponent<NPCHints>());
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame() && objNameSO.Value == "Pen")
        {
            spriteRenderer.sprite = newStatus;
            objNameSO.Value = null;
            LevelManager.instance.CheckStatus();
            statusChanged = true;
            Destroy(GetComponent<NPCHints>());
            Destroy(transform.GetChild(0).gameObject);
            HerbalAnim.instance.getHerbal = true;
            AudioManager.instance.PlaySFX(6);
            herbalCount.Value += 1;
        }
    }
}
