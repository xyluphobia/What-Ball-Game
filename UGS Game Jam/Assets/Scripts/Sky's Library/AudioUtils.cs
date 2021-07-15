using System.Collections;
using UnityEngine;

namespace Skypex
{
    public class AudioUtils
    {
        public static void CrossFade(AudioSource sourceToFadeIn, AudioSource sourceToFadeOut, float targetFadeInVolume, float targetFadeOutVolume, float fadeTime, float delay = 0)
        {
            MonoBehaviour behaviour = sourceToFadeIn.GetComponent<MonoBehaviour>();
            behaviour.StartCoroutine(FadeInRoutine(sourceToFadeIn, fadeTime, targetFadeInVolume, delay));
            behaviour.StartCoroutine(FadeOutRoutine(sourceToFadeOut, fadeTime, targetFadeOutVolume, delay));
        }

        public static IEnumerator FadeInRoutine(AudioSource audioSource, float fadeTime, float targetVolume, float delay = 0)
        {
            if (delay > 0)
                yield return new WaitForSeconds(delay);

            float startVolume = 0.2f;

            audioSource.volume = 0;
            audioSource.Play();

            while (audioSource.volume < targetVolume)
            {
                audioSource.volume += startVolume * Time.deltaTime / fadeTime;
                yield return null;
            }

            audioSource.volume = 1f;
        }

        public static IEnumerator FadeOutRoutine(AudioSource audioSource, float fadeTime, float targetVolume, float delay = 0)
        {
            if (delay > 0)
                yield return new WaitForSeconds(delay);

            float startVolume = audioSource.volume;

            while (audioSource.volume > targetVolume)
            {
                audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
                yield return null;
            }

            audioSource.Stop();
            audioSource.volume = startVolume;
        }
    }

    namespace ExtensionMethods
    {
        public static class AudioUtilsE
        {
            public static void FadeIn(this AudioSource audioSource, float fadeTime, float targetVolume, float delay = 0) =>
                audioSource.GetComponent<MonoBehaviour>().StartCoroutine(AudioUtils.FadeInRoutine(audioSource, fadeTime, targetVolume, delay));

            public static void FadeOut(this AudioSource audioSource, float fadeTime, float delay = 0) =>
                audioSource.GetComponent<MonoBehaviour>().StartCoroutine(AudioUtils.FadeOutRoutine(audioSource, fadeTime, 0f, delay));

            public static void FadeOut(this AudioSource audioSource, float fadeTime, float targetVolume, float delay = 0) =>
                audioSource.GetComponent<MonoBehaviour>().StartCoroutine(AudioUtils.FadeOutRoutine(audioSource, fadeTime, targetVolume, delay));
        }
    }
}