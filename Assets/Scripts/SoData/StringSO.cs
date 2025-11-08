using UnityEngine;

[CreateAssetMenu]
public class StringSO : ScriptableObject
{
    [SerializeField]
    private string obj;
    public string Value
    {
        get { return obj; }
        set { obj = value; }
    }

}
