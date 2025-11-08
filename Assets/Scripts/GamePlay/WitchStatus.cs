using UnityEngine;

public class WitchStatus : MonoBehaviour
{
    [SerializeField]
    private IntSO herbalCount;
    public Sprite weakStatus;
    public Sprite goneStatus;
    private SpriteRenderer spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (herbalCount.Value is > 0 and < 3)
        {
            spriteRenderer.sprite = weakStatus;
            Destroy(GetComponent<NPCHints>());
            Destroy(transform.GetChild(0).gameObject);
        }
        else if (herbalCount.Value == 3)
        {
            spriteRenderer.sprite = goneStatus;
            Destroy(GetComponent<NPCHints>());
            Destroy(transform.GetChild(0).gameObject);
        }

    }


}
