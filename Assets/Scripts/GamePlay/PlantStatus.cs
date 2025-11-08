using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



public class PlantStatus : MonoBehaviour
{
    private bool ifPlayerCollides;
    private Collider2D triggerCollider;
    private LayerMask playerLayer;
    private Animator animator;


    [SerializeField]
    private StringSO objNameSO;
    private bool edible;
    private static bool plantRemoved;

    InputAction interactAction;


    void Awake()
    {
        if (plantRemoved)
        {
            Destroy(gameObject);
        }


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
        triggerCollider = GetComponent<Collider2D>();
        playerLayer = 1 << LayerMask.NameToLayer("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ifPlayerCollides = triggerCollider.IsTouchingLayers(playerLayer);
        if (ifPlayerCollides && interactAction.WasPressedThisFrame())
        {
            if (objNameSO.Value == "Pumpkin" || objNameSO.Value == "Spider" || objNameSO.Value == "Mushroom")
            {
                edible = true;
                objNameSO.Value = null;
                AudioManager.instance.PlaySFX(10);
                LevelManager.instance.CheckStatus();
                StartCoroutine(WaitForAnimation("Garden_PlantEat"));
            }
            else if (objNameSO.Value == "Pot")
            {
                Destroy(gameObject);
                AudioManager.instance.PlaySFX(11);
                PickablesManagement.Instance.UpdateDrop("Plant", "花园", new Vector3(2.73f, -3.68f, 0f));
                objNameSO.Value = null;
                LevelManager.instance.CheckStatus();
                plantRemoved = true;


            }

        }
        animator.SetBool("edible", edible);
    }

    private IEnumerator WaitForAnimation(string stateName)
    {
        // Wait until the animator is actually in the state
        //yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(stateName));

        // Wait for the duration of the state
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        edible = false;
    }
    

}


