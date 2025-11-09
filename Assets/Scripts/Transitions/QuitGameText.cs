using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



public class QuitGameText : MonoBehaviour
{
    public TextMeshProUGUI myText;
    InputAction interactAction;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        myText.enabled = false;
        interactAction = InputSystem.actions.FindAction("Quit");

    }

    // Update is called once per frame
    void Update()
    {
        if (RollingText.stop == true)
        {
            myText.enabled = true;
            if (interactAction.WasPressedThisFrame())
            {
                Application.Quit();
            }

        }
    }
}
