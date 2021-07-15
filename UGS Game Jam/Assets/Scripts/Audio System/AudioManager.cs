using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Skypex.ExtensionMethods;
using Skypex;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager _instance;

    public static AudioManager Instance => _instance;

    private void CreateSingleton()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
    #endregion

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume = 1f;
        [Range(.1f, 3f)] public float pitch = 1f;
        [HideInInspector] public AudioSource source;
    }

    [SerializeField] private AudioMixer mixer;
    [Space]
    public List<Sound> SoundEffects = new List<Sound>();
    [SerializeField] private List<Sound> Music = new List<Sound>();
    [SerializeField] private List<Sound> VoiceLines = new List<Sound>();

    private void Awake()
    {
        CreateSingleton();

        foreach (Sound sound in Music)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.outputAudioMixerGroup = mixer.FindMatchingGroups("Music")[0];

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = true;
        }

        foreach (Sound sound in VoiceLines)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.outputAudioMixerGroup = mixer.FindMatchingGroups("Voice Lines")[0];

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }

        foreach (Sound sound in SoundEffects)
        {
            sound.source.outputAudioMixerGroup = mixer.FindMatchingGroups("SFX")[0];
        }
    }

    private void Start()
    {
        SetDistortLevel(0f);
    }

    public void PlayMusic(string name)
    {
        Sound sound = GetMusicClip(name);
        if (sound is null)
            return;

        sound.source.Play();
    }

    public void PlayVoiceLine()
    {
        Sound sound = GetVoiceLineClip(name);
        if (sound is null)
            return;

        sound.source.Play();
    }

    public void SetDistortLevel(float level)
    {
        mixer.SetFloat("Music Distortion", level);
        mixer.SetFloat("SFX Distortion", level);
    }

    public static void FadeIn(AudioSource source, float fadeTime, float targetVolume, float delay = 0)
    {
        AudioUtilsE.FadeIn(source, fadeTime, targetVolume, delay);
    }

    public static void FadeOut(AudioSource source, float fadeTime, float targetVolume, float delay = 0)
    {
        AudioUtilsE.FadeOut(source, fadeTime, targetVolume, delay);
    }

    public static void CrossFade(AudioSource sourceToFadeIn, AudioSource sourceToFadeOut, float targetFadeInVolume, float targetFadeOutVolume, float fadeTime, float delay = 0)
    {
        AudioUtils.CrossFade(sourceToFadeIn, sourceToFadeOut, targetFadeInVolume, targetFadeOutVolume, fadeTime, delay);
    }

    private Sound GetMusicClip(string name) => Music.Find(sound => sound.name == name);

    private Sound GetSFXClip(string name) => SoundEffects.Find(sound => sound.name == name);

    private Sound GetVoiceLineClip(string name) => VoiceLines.Find(sound => sound.name == name);
}