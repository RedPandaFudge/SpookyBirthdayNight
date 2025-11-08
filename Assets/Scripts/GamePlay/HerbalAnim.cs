using UnityEngine;
using System.Collections;

public class HerbalAnim : MonoBehaviour
{
    private Animator animator;
    public bool getHerbal;
    private SpriteRenderer SR;

    public static HerbalAnim instance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;
        SR = GetComponent<SpriteRenderer>();
        SR.enabled = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getHerbal)
        {
            SR.enabled = true;
            StartCoroutine(WaitForAnimation("Player_Herbal"));
        }

        animator.SetBool("getHerbal", getHerbal);
    }

    private IEnumerator WaitForAnimation(string stateName)
    {
        // Wait until the animator is actually in the state
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName(stateName));

        // Wait for the duration of the state
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        getHerbal = false;
        SR.enabled = false;
    }
}
