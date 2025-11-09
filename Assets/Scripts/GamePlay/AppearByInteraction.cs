using UnityEngine;
using UnityEngine.InputSystem;

public class AppearByInteraction : MonoBehaviour
{
    private bool ifPlayerCollides;
    private bool spriteAppears;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    public SpriteRenderer spriteToShow;


    InputAction interactAction;



    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        // Get the Collider2D attached to this GameObject
        triggerCollider = GetComponent<Collider2D>();

        // Get the layer index of "Player" and convert to a LayerMask
        playerLayer = 1 << LayerMask.NameToLayer("Player");

    }

    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame())
        {

            if (spriteAppears)
            {   // Hide sprite if it is already displaying
                spriteToShow.enabled = false;
                spriteAppears = false;
            }
            else
            {
                spriteToShow.enabled = true;
                AudioManager.instance.PlaySFX(5);
                spriteAppears = true;
            }


        }
    }

}
