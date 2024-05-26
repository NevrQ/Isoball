using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip levelMusicClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = levelMusicClip;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
