using UnityEngine;
using UnityEngine.InputSystem;

public class LobbyPumpkinCat : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool ifPlayerCollides;
    private bool ifInteracted;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;


    InputAction interactAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Get the Collider2D attached to this GameObject
        triggerCollider = GetComponent<Collider2D>();

        // Get the layer index of "Player" and convert to a LayerMask
        playerLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame())
        {
            ifInteracted = true;
            AudioManager.instance.PlaySFX(4);
        } else
        {
            ifInteracted = false;
        }    
    animator.SetBool("ifInteracted", ifInteracted);
    }

}
