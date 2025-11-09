using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionAnim : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool ifPlayerCollides;
    private bool ifInteracted;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    public AudioClip soundEffect;
    private AudioSource audioSource;


    InputAction interactAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame())
        {
            ifInteracted = true;
            audioSource.PlayOneShot(soundEffect);

        }
        else
        {
            ifInteracted = false;
        }

        animator.SetBool("ifInteracted", ifInteracted);
    }

}
