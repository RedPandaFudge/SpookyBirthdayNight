using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public static FadeScreen instance;

    private Image fadeScreen;
    public float fadeSpeed;
    public bool shouldFadeToBlack, shouldFadeFromBlack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {   
        instance = this;
        fadeScreen = GetComponent<Image>();
    }

    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {   
        
        if(shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
            Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeToBlack = false;
            }
        } else if(shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, 
            Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1f)
            {
                shouldFadeFromBlack = false;
            }
    }
}


public void FadeToBlack()
{
    shouldFadeToBlack = true;
    shouldFadeFromBlack = false;
}

public void FadeFromBlack()
{
    shouldFadeToBlack = false;
    shouldFadeFromBlack = true;
}

}

