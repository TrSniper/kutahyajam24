using UnityEngine;
using UnityEngine.Audio;

public class SoundManager: MonoSingleton<SoundManager>
{
    [SerializeField] AudioMixerGroup mixerGroup;
    /// <summary>
    /// Plays an AudioClip from an array at a specified position with a given volume and optional AudioMixerGroup.
    /// </summary>
    /// <param name="clips">Array of AudioClips to choose from.</param>
    /// <param name="clipIndex">Index of the clip to play within the array.</param>
    /// <param name="location">The Transform location where the clip should play.</param>
    /// <param name="volume">The volume for playback (default is 1.0f).</param>

    /// <summary>
    /// Plays an AudioClip from an array at a specified position with a given volume and optional AudioMixerGroup.
    /// </summary>
    /// <param name="clips">Array of AudioClips to choose from.</param>
    /// <param name="clipIndex">Index of the clip to play within the array.</param>
    /// <param name="location">The Transform location where the clip should play.</param>
    /// <param name="volume">The volume for playback (default is 1.0f).</param>
    /// <param name="mixer">Optional AudioMixerGroup to route the audio through a mixer.</param>
    public void PlayClipAtPosition(AudioClip[] clips, int clipIndex, Transform location, float volume = 1.0f, AudioMixerGroup mixer = null)
    {
        if (clipIndex < 0 || clipIndex >= clips.Length)
        {
            Debug.LogWarning("AudioManager: PlayClipAtPosition was called with an invalid clip index.");
            return;
        }

        AudioClip clip = clips[clipIndex];
        PlayClipAtPosition(clip, location, volume, mixer);
    }

    /// <summary>
    /// Overload: Plays a single AudioClip at a specified position with a given volume and optional AudioMixerGroup.
    /// </summary>
    /// <param name="clip">The AudioClip to play.</param>
    /// <param name="location">The Transform location where the clip should play.</param>
    /// <param name="volume">The volume for playback (default is 1.0f).</param>
    /// <param name="mixer">Optional AudioMixerGroup to route the audio through a mixer.</param>
    public void PlayClipAtPosition(AudioClip clip, Transform location, float volume = 1.0f, AudioMixerGroup mixer = null)
    {
        if (clip == null || location == null)
        {
            Debug.LogWarning("AudioManager: PlayClipAtPosition was called with a null clip or location.");
            return;
        }

        GameObject tempAudioSource = new GameObject("TempAudioSource_" + clip.name);
        tempAudioSource.transform.position = location.position;

        AudioSource audioSource = tempAudioSource.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.spatialBlend = 1.0f; // Ensures the sound is 3D
        audioSource.outputAudioMixerGroup = mixer ?? this.mixerGroup; // Use specified mixer or default
        audioSource.Play();

        Destroy(tempAudioSource, clip.length);
    }
}

