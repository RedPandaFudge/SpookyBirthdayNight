using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.SceneManagement;

public class PickDropItem : MonoBehaviour
{
    private InputAction dropAction;
    private InputAction pickUpAction;
    private Collider2D currentPickable;
    public static PickDropItem instance;
    [SerializeField]
    private StringSO objNameSO;

    private void Awake()
    {
        instance = this;
        dropAction = InputSystem.actions.FindAction("Drop");
        pickUpAction = InputSystem.actions.FindAction("Interact");
    
    }


    void Update()
    {
        if (dropAction.WasPressedThisFrame() && objNameSO.Value != null)
        {
            Debug.Log("Dropping item");
            DoDropItem(objNameSO.Value);

        }
        else if (pickUpAction.WasPressedThisFrame() && currentPickable != null)
        {   // Drop current item and pick up new item
            if (objNameSO.Value != null)
            {
                DoDropItem(objNameSO.Value);
            }
            Debug.Log("Ready to pick up");
            DoPickUp(currentPickable);
            currentPickable = null;

        }
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pickables"))
        {
            currentPickable = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == currentPickable)
        {
            currentPickable = null;
        }
    }


    private void DoDropItem(string objName)
    {
        objNameSO.Value = null;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log("Item dropped, placed in new scene: " + sceneName);
        AudioManager.instance.PlaySFX(15);
        PickablesManagement.Instance.UpdateDrop(objName, sceneName, PlayerController.instance.groundCheckPoint.position);



        LevelManager.instance.CheckStatus();

    }



    public void DoPickUp(Collider2D collision)
    {
        objNameSO.Value = collision.gameObject.name;
        Debug.Log("Picking up: " + objNameSO.Value);
        AudioManager.instance.PlaySFX(14);
        PickablesManagement.Instance.SetCollected(objNameSO.Value);
        Debug.Log(objNameSO.Value + "picked up");
        Destroy(collision.gameObject);
        Debug.Log(objNameSO.Value + "destroyed");
        
        LevelManager.instance.CheckStatus();
        
        
    }
    
}
