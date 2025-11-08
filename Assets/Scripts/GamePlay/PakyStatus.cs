using UnityEngine;
using UnityEngine.InputSystem;

public class PakyStatus : MonoBehaviour
{
    private bool ifPlayerCollides;
    private Collider2D triggerCollider;
    private LayerMask playerLayer;

    [SerializeField]
    private IntSO herbalCount;
    public static bool getHerbal;

    InputAction interactAction;



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
        if (ifPlayerCollides && interactAction.WasPressedThisFrame() && !getHerbal)
        {
            HerbalAnim.instance.getHerbal = true;
            AudioManager.instance.PlaySFX(6);
            herbalCount.Value += 1;
            getHerbal = true;
        }
    }
}
