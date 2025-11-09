using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThornStatus : MonoBehaviour
{
    private bool ifPlayerCollides;
    private SpriteRenderer spriteRenderer;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;
    private static bool ThornsRemoved;
    public SpriteRenderer hintToShow;


    [SerializeField]
    private StringSO objNameSO;
    InputAction interactAction;


    void Awake()
    {   
        if (ThornsRemoved)
        {
            Destroy(gameObject);   
        }
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        interactAction = InputSystem.actions.FindAction("Interact");
        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides)
        {
            if (interactAction.WasPressedThisFrame() && objNameSO.Value == "Plant")
            {
                // Disable knockback and allow player to interact when holding Plant
                Destroy(gameObject);
                objNameSO.Value = null;
                AudioManager.instance.PlaySFX(12);
                LevelManager.instance.CheckStatus();
                ThornsRemoved = true;

            }
            else if (objNameSO.Value != "Plant")
            {
                PlayerController.instance.KnockBack();
                AudioManager.instance.PlaySFX(13);
                StartCoroutine(showHint());
            }
        }
    }
    
    public IEnumerator showHint()
    {
        hintToShow.enabled = true;
        yield return new WaitForSeconds(1.5f);
        hintToShow.enabled = false;
    }

}
