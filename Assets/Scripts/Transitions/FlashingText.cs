using TMPro;
using UnityEngine;

public class FlashingText : MonoBehaviour
{
    [SerializeField] float fadeSpeed;
    private float minAlpha = 0f;
    private float maxAlpha = 1f;
    public TextMeshProUGUI myText;

    TMP_Text text;
    bool fadingOut = true;

    void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        var c = text.color;
        float target = fadingOut ? minAlpha : maxAlpha;

        if (myText.enabled == true)
        {
            c.a = Mathf.MoveTowards(c.a, target, fadeSpeed * Time.deltaTime);
            text.color = c;

        if (Mathf.Approximately(c.a, target))
            fadingOut = !fadingOut; // flip direction when we hit the target

        }

        
    }
}
