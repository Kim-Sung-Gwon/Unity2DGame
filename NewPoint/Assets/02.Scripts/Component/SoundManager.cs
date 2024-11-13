using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public float SoundVolumn = 1;
    public bool isSoundMute = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(Vector3 pos, AudioClip clip)
    {
        if (isSoundMute) return;
        GameObject soundObj = new GameObject("Sound");
        AudioSource audioSource = soundObj.AddComponent<AudioSource>();

        audioSource.clip = clip;
        audioSource.minDistance = 10;
        audioSource.maxDistance = 20;
        audioSource.volume = SoundVolumn;
        audioSource.Play();
        Destroy(soundObj, clip.length);
    }
}
