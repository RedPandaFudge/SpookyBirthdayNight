using UnityEngine;

public class NPCHints : MonoBehaviour
{
    //private SpriteRenderer spriteRenderer;
    private bool ifPlayerCollides;
    //private bool ifInteracted;

    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    public SpriteRenderer hintToShow;
    bool wasColliding = false;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        triggerCollider = GetComponent<Collider2D>();

        playerLayer = 1 << LayerMask.NameToLayer("Player");
        hintToShow.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && !wasColliding)
        {   
            // Show hint only when player is colliding with NPC
            hintToShow.enabled = true;
            AudioManager.instance.PlaySFX(5);
        }
        else if (!ifPlayerCollides && wasColliding)
        {
            hintToShow.enabled = false;
        }

        wasColliding = ifPlayerCollides;
    }
}

