using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    private AudioSource audioSource;

    [SerializeField] private AudioClip impactClip;
    [SerializeField] private AudioClip pointClip;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip _audioClip)
    {
        audioSource.clip = _audioClip;
        audioSource.Play();
    }

    public void PlayImpact()
    {
        Play(impactClip);
    }

    public void PlayPoint()
    {
        Play(pointClip);
    }
}
