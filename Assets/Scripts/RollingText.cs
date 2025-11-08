using UnityEngine;

public class RollingText : MonoBehaviour
{
    public float scrollSpeed; 
    public float stopY;
    private RectTransform rectTransform;
    public static bool stop;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stop = false;
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rectTransform.anchoredPosition.y < stopY)
        {
            rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
        }
        else
        {
            stop = true;
        }
        
    }
}
