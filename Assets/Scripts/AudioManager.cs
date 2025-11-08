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

    
       /*public IEnumerator PlaySFX(int soundToPlay)
    {

        soundEffects[soundToPlay].Stop();
        soundEffects[soundToPlay].Play();

        // wait until finished
        yield return new WaitWhile(() => soundEffects[soundToPlay].isPlaying);
    }    */
}
