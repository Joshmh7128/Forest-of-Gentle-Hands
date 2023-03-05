using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeirdTalk : MonoBehaviour
{
    [SerializeField] AudioSource voiceSource; // the audio source
    [SerializeField] int remainingSyllables; // how many syllables are left
    [SerializeField] float syllableLength, pitchMin, pitchMax; // how fast can this speak?

    private void Start()
    {
        StartCoroutine(SpeakSyllable());
    }

    public void RequestSyllable()
    {
        remainingSyllables++;
    }

    IEnumerator SpeakSyllable()
    {
        // if there is a syllable to say
        if (remainingSyllables > 0)
        {
            // remove one
            remainingSyllables--;
            // wait
            yield return new WaitForSecondsRealtime(Random.Range(syllableLength / 2, syllableLength));
            // pitch shift
            voiceSource.pitch = Random.Range(pitchMin, pitchMax);
            // choose noise
            voiceSource.time = Random.Range(0f, voiceSource.clip.length);
            // play
            voiceSource.Play();

            // start coroutine again
            StartCoroutine(SpeakSyllable());
        }
        else
        {
            voiceSource.Stop();
            // timeshare this over and over as a step on all voices
            yield return new WaitForSecondsRealtime(Random.Range(0.5f, 1));
            // start coroutine again
            StartCoroutine(SpeakSyllable());
        }
    }
}
