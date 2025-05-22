using UnityEngine;

public class audioManagerr : MonoBehaviour
{
    [Header("------audiosource")]
    [SerializeField] AudioSource musicsource;
    [SerializeField] AudioSource sfxsource;

    [Header("------audioclip")]
    public AudioClip background;
    public AudioClip checkpoint;
    public AudioClip death;
    public AudioClip keys;
    public AudioClip lever;
    public AudioClip tp;
    public AudioClip interaction;
    public AudioClip ambulance;
    private void Start()
    {
        musicsource.clip = background; 
        musicsource.Play();
    }

    public void Playsfx(AudioClip clip)
    {
        sfxsource.PlayOneShot(clip);
    }
}
