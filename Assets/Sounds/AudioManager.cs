using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] rireListe;
    [SerializeField] private AudioClip guiliSound;
    private AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void RireSon()
    {
        int num = Random.Range(0, rireListe.Length);
        source.PlayOneShot(rireListe[num]);
    }

    public void GuyLee()
    {
        source.PlayOneShot(guiliSound);
    }
}