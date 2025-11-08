using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class ForceRatio : MonoBehaviour
{
    // Your design aspect, e.g. 16:9
    public Vector2 targetAspect = new Vector2(16, 9);

    Camera cam;
    int lastW, lastH;

    void OnEnable() { cam = GetComponent<Camera>(); Apply(); }
    void Update()
    {
        if (Screen.width != lastW || Screen.height != lastH) Apply();
    }

    void Apply()
    {
        if (!cam) cam = GetComponent<Camera>();

        float target = targetAspect.x / targetAspect.y;
        float window = (float)Screen.width / Screen.height;

        if (window > target)
        {
            // Pillarbox: too wide → reduce width
            float scale = target / window;
            float x = (1f - scale) * 0.5f;
            cam.rect = new Rect(x, 0f, scale, 1f);
        }
        else
        {
            // Letterbox: too tall → reduce height
            float scale = window / target;
            float y = (1f - scale) * 0.5f;
            cam.rect = new Rect(0f, y, 1f, scale);
        }

        lastW = Screen.width;
        lastH = Screen.height;
    }
}
