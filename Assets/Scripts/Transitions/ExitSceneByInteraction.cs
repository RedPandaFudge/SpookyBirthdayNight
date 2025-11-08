using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ExitSceneByInteraction : MonoBehaviour
{
    public static ExitSceneByInteraction instance;
    public string levelToLoad;

    InputAction interactAction;

    private bool ifPlayerCollides;
    private Collider2D triggerCollider;
    private LayerMask playerLayer;
    public Vector3 playerPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        string objectName = gameObject.name;

        if (objectName == "锅")
        {
            interactAction = InputSystem.actions.FindAction("Interact");

        }
        else
        {
            interactAction = InputSystem.actions.FindAction("Exit");
        }


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
            if (levelToLoad != "锅")
            {
                AudioManager.instance.PlaySFX(0);
            }
            
            LevelManager.instance.SwitchScene(levelToLoad, playerPos);

        }
    }

}
