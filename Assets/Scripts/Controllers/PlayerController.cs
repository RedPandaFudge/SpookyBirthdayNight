using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour

{
    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D rigidBody;
    InputAction moveAction;
    InputAction jumpAction;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    private bool secondJumpAllowed;
    public string sceneName;


    public float knockBackLength, knockBackForce;
    private float knockBackCounter;



    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer eyesSR;
    [SerializeField] private SpriteRenderer blackSR;
    private Transform eyes;
    private Transform blackMask;

    public static PlayerController instance;




    void Awake()
    {
        instance = this;
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        eyes = transform.Find("ChiramEyes");
        blackMask = transform.Find("ChiramBlack");

        if (sceneName == "长颈鹿房间" && !KirinLightSwitch.lightOn)
        {
            // Enable eyes and the black mask in the dark room
            eyes.gameObject.SetActive(true);
            blackMask.gameObject.SetActive(true);
        }
        else
        {
            eyes.gameObject.SetActive(false);
            blackMask.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (knockBackCounter <= 0)
        {
            // 4. Read the "Move" action value, which is a 2D vector
            // and the "Jump" action state, which is a boolean value

            Vector2 moveValue = moveAction.ReadValue<Vector2>();
            rigidBody.linearVelocity = new Vector2(moveSpeed * moveValue.x, rigidBody.linearVelocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, groundLayer);



            if (jumpAction.WasPressedThisFrame())
            {
                if (isGrounded)
                {
                    // Allow second jump if player is touching the ground
                    rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpHeight);
                    AudioManager.instance.PlaySFX(19);
                    secondJumpAllowed = true;
                }
                else if (secondJumpAllowed)
                {
                    rigidBody.linearVelocity = new Vector2(rigidBody.linearVelocity.x, jumpHeight);
                    AudioManager.instance.PlaySFX(19);
                    secondJumpAllowed = false;
                }
            }

            if (rigidBody.linearVelocity.x < 0)
            {
                // Flip player sprite horizontally if facing left
                spriteRenderer.flipX = true;
                eyesSR.flipX = true;
                blackSR.flipX = true;
            }
            else if (rigidBody.linearVelocity.x > 0)
            {
                spriteRenderer.flipX = false;
                eyesSR.flipX = false;
                blackSR.flipX = false;
            }
            if (KirinLightSwitch.lightOn)
            {
                eyes.gameObject.SetActive(false);
                blackMask.gameObject.SetActive(false);
            }


        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        animator.SetFloat("speed", Mathf.Abs(rigidBody.linearVelocity.x));
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("jumpPressed", jumpAction.WasPressedThisFrame());
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        rigidBody.linearVelocity = new Vector2(-knockBackForce, knockBackForce);

    }


}
