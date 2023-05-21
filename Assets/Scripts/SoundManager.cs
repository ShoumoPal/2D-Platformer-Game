using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource soundsBG;
    public AudioSource soundsSFX;
    public AudioSource soundFootstep;

    public SoundType[] sounds;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBGMusic(Sounds sound)
    {
        PlayMusic(sound);
    }
    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        soundsBG.clip = clip;
        soundsBG.volume = GetVolume(sound);
        soundsBG.Play();
    }
    public void StopBGMusic()
    {
        soundsBG.Stop();
    }
    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        soundsSFX.clip = clip;
        soundsSFX.volume = GetVolume(sound);
        if (clip != null)
        {
            soundsSFX.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No audio clips detected");
        }
    }
    public void Stop()
    {
        soundsSFX.Stop();
    }
    public void PlayFootstep()
    {
        soundFootstep.clip = GetSoundClip(Sounds.Footsteps);
        soundFootstep.volume = GetVolume(Sounds.Footsteps);
        soundFootstep.Play();
    }
    public bool isPlayingFootstep()
    {
        return soundFootstep.isPlaying;
    }
    public void StopFootstep()
    {
        soundFootstep.Stop();
    }
    private float GetVolume(Sounds sound)
    {
        SoundType s = Array.Find(sounds, i => i.soundType == sound);
        return s.volume;
    }
    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item = Array.Find(sounds, i => i.soundType == sound);
        return item.soundClip;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;

    [Range(0f, 1f)]
    public float volume;
}
public enum Sounds
{
    Background,
    ButtonClick,
    PlayerJump,
    DisabledButton,
    Pickup,
    Footsteps,
    DeathMusic,
    LevelComplete
}

