using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioClip skeletonHitSound1;
    public AudioClip skeletonHitSound2;
    public AudioClip skeletonHitSound3;
    public AudioClip skeletonHitSound4;
    static AudioSource audioSrc;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        switch (Random.Range(0,4))
        {
            case 0:
                audioSrc.PlayOneShot(skeletonHitSound1);
                break;
            case 1:
                audioSrc.PlayOneShot(skeletonHitSound2);
                break;
            case 2:
                audioSrc.PlayOneShot(skeletonHitSound3);
                break;
            case 3:
                audioSrc.PlayOneShot(skeletonHitSound4);
                break;
        }
    }
}
