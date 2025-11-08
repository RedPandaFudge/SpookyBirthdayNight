using System.Runtime.CompilerServices;
using UnityEngine;

public class HerbalStatus : MonoBehaviour
{
    [SerializeField]
    private IntSO herbalCount;
    
    [SerializeField] GameObject flash;
    [SerializeField] GameObject herbals;
    [SerializeField] GameObject basil;
    [SerializeField] GameObject rosemary;

    void Awake()
    {

        switch (herbalCount.Value)
        {
            case 0:
                herbals.SetActive(false);
                break;
            case 1:
                basil.SetActive(false);
                rosemary.SetActive(false);
                break;
            case 2:
                rosemary.SetActive(false);
                break;
        }
    }



}
