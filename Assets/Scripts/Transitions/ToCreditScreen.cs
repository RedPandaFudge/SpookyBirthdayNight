using UnityEngine;
using UnityEngine.InputSystem;

public class toCreditScreen : MonoBehaviour
{
    InputAction interactAction;
    public string levelToLoad;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");

    }

    // Update is called once per frame
    void Update()
    {
        if (interactAction.WasPressedThisFrame())
        {

            LevelManager.instance.SwitchScene(levelToLoad, new Vector3(-10000, 0, 0));


        }
    }

}
