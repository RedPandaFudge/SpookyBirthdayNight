using UnityEngine;
using UnityEngine.InputSystem;

public class AppearByInteraction : MonoBehaviour
{
    private bool ifPlayerCollides;
    //private bool ifInteracted;
    private bool spriteAppears;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    public SpriteRenderer spriteToShow;


    InputAction interactAction;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

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

            if (spriteAppears)
            {
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
