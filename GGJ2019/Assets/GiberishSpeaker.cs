using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GiberishSpeaker : MonoBehaviour
{
    public AudioClip[] mouthSounds;
    public AudioSource audioSource;

    private int tempSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(Random.Range(0, mouthSounds.Length));

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            print("soundPlaying");
            PlaySound(Random.Range(0, mouthSounds.Length));
        }

    }

    public void PlaySound(int index)
    {
        audioSource.clip = mouthSounds[index];
        audioSource.PlayOneShot(audioSource.clip);

    }
}
