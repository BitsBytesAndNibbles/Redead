using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;
    public AudioClip MainTheme;
    public AudioClip GameTheme;
    public AudioSource musicSrc;


    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        musicSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic(int selection)
    {
        switch (selection)
        {
            case 0:
                musicSrc.clip = (MainTheme);
                musicSrc.Play();
                break;
            case 1:
                musicSrc.clip = (GameTheme);
                musicSrc.Play();
                break;
        }

    }
}
