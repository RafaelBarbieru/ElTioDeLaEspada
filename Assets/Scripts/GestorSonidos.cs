using System;
using UnityEngine;
using UnityEngine.Audio;

public class GestorSonidos : MonoBehaviour
{
    private AudioSource[] fuenteSonidos;
    public AudioMixer audioMixer;

    private void Start()
    {
        fuenteSonidos = GetComponents<AudioSource>();
    }
    public void setVolumenMusica(float volumen)
    {
        audioMixer.SetFloat("volumenMusica", volumen);
    }
    public void setVolumenSFX(float volumen)
    {
        audioMixer.SetFloat("volumenSFX", volumen);
        Array.Find<AudioSource>(fuenteSonidos, audio => audio.clip.name == "Atacar").Play();
    }
}
