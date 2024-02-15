using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxCource;

    public AudioClip bgmClip;
    public AudioClip mapChangeClip;
    public AudioClip fireBallClip;
    public AudioClip slimeDieClip;
    public AudioClip uiSelectClip;
    public AudioClip walkClip;


    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider masterSlider;


    public void PlaySFX(AudioClip clip)
    {
        if (clip == walkClip && sfxCource.isPlaying)
            return;
        sfxCource.PlayOneShot(clip);
    }
    void Start()
    {
        bgmSource.clip = bgmClip;
        bgmSource.Play();
    }
}
