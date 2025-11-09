using UnityEngine;

public class KitchenCat : MonoBehaviour
{
    private Animator animator;
    //public KitchenCat instance;
    private static bool YarnBallExists;
    public string Kitchen_CatPlay;
    private bool broomExists;

    void Awake()
    {
        animator = GetComponent<Animator>();
        YarnBallExists = Yarnball.YarnBallExists;

        if (YarnBallExists)
        {
            animator.Play(Kitchen_CatPlay, 0, 1f);
            // Force the pose to apply the last frame of animation
            animator.Update(0f);
            animator.speed = 0f;
        } else
        {
            broomExists = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        YarnBallExists = Yarnball.YarnBallExists;
        if (YarnBallExists && broomExists)
        {
            AudioManager.instance.PlaySFX(3);
            PickablesManagement.Instance.UpdateDrop("Pen", "厨房餐厅", new Vector3(2.88f, -2.74f, 0f));
            broomExists = false;

        }
        animator.SetBool("YarnBallExists", YarnBallExists);
    }
}
