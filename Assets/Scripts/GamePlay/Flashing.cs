using UnityEngine;

public class Flashing : MonoBehaviour
{

    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("flashOn", HerbalPotStatus.flashOn);
    }
    
}
