using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;
    public AudioSource Bgm, Ending;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


  
    public void PlaySFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();
        // Adjust pitch for jumping sfx
        if (soundToPlay == 19)
        {
            soundEffects[soundToPlay].pitch = Random.Range(.75f, .8f);
        }
        else
        {
            soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        }
        soundEffects[soundToPlay].Play();
        

    }

}
