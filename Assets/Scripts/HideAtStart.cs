using UnityEngine;

public class HideAtStart : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {   
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
}
