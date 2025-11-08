using UnityEngine;
using UnityEngine.InputSystem;

public class KirinLightSwitch : MonoBehaviour
{

    private bool ifPlayerCollides;
    private Collider2D triggerCollider;
    private LayerMask playerLayer;
    public static bool lightOn;
    public GameObject lightOff;
    InputAction interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (lightOn)
        {
            Destroy(lightOff);
        }

        interactAction = InputSystem.actions.FindAction("Interact");
        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame() && !lightOn)
        {
            AudioManager.instance.PlaySFX(7);
            Destroy(lightOff);
            lightOn = true;
        }
    }
}
