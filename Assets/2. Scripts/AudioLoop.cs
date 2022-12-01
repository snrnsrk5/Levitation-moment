using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    public AudioSource clip;
    public float loop;
    public float count;
    public ParticleSystem particleSystem;
    void Start()
    {
        InvokeRepeating("Sound", count, loop);
    }

    public void Sound()
    {
        particleSystem.Play();
        float pitch = Random.RandomRange(0.8f, 1.4f);
        clip.pitch = pitch;
        clip.Play();
    }
}
