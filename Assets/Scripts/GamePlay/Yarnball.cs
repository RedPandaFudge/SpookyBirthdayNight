using UnityEngine;
using UnityEngine.InputSystem;

public class Yarnball : MonoBehaviour
{
    private bool ifPlayerCollides;
    private SpriteRenderer spriteRenderer;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;


    [SerializeField]
    private StringSO objNameSO;
    public static bool YarnBallExists;



    InputAction interactAction;


    void Awake()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (!YarnBallExists)
        {
            spriteRenderer.enabled = false;   
        }
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        if (ifPlayerCollides && interactAction.WasPressedThisFrame() && objNameSO.Value == "Broom")
        {
            if (!spriteRenderer.enabled)
            {
                AudioManager.instance.PlaySFX(9);
                spriteRenderer.enabled = true;
                objNameSO.Value = null;
                LevelManager.instance.CheckStatus();
                YarnBallExists = true;
                


            }
            
        } 
    }

}
