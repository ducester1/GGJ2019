using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class GiberishSpeaker : MonoBehaviour
{
    public AudioClip[] mouthSounds;
    public AudioSource audioSource;
    public float MinPitch;
    public float MaxPitch;

    private int tempSound;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(MinPitch, MaxPitch);
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
        if(index == tempSound)
        {
            PlaySound(Random.Range(0, mouthSounds.Length));
        }
        else
        {
            tempSound = index;
            audioSource.clip = mouthSounds[index];
            audioSource.PlayOneShot(audioSource.clip);
        }


    }
}
