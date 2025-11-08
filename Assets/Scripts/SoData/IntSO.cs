using UnityEngine;

[CreateAssetMenu]
public class IntSO : ScriptableObject
{
    [SerializeField]
    private int count;
    public int Value
    {
        get { return count; }
        set { count = value; }
    }

}
