using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CountingInteractionAnim : MonoBehaviour
{
    private Animator animator;
    private bool ifPlayerCollides;
    private bool ifInteracted;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;
    private int counter;

    public GameObject curtainToDestory;
    private static bool curtainMoved;


    InputAction interactAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        animator = GetComponent<Animator>();

        // Get the Collider2D attached to this GameObject
        triggerCollider = GetComponent<Collider2D>();

        // Get the layer index of "Player" and convert to a LayerMask
        playerLayer = 1 << LayerMask.NameToLayer("Player");

        counter = 0;

        if(curtainMoved)
        {
            Destroy(curtainToDestory);
        }
    }

    // Update is called once per frame
    void Update()
    {

        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame())
        {
            ifInteracted = true;
            
            AudioManager.instance.PlaySFX(4);

            if (counter <= 2)
            {
                counter += 1;
            } 
            
            if (counter >= 3 && PakyStatus.getHerbal == true)
            {
                AudioManager.instance.PlaySFX(3);
                Destroy(curtainToDestory);
                curtainMoved = true;
            }
        }
        else
        {
            ifInteracted = false;
        }


        animator.SetBool("ifInteracted", ifInteracted);
        animator.SetBool("curtainMoved", curtainMoved);

    }



}
