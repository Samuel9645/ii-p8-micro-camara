using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour {
  public MicrophoneRecorder recorder;

  private void Start() {
    _audioSource = GetComponent<AudioSource>();
    if (recorder != null) {
      recorder.OnRecordEnd += PlayAudioClip;
    } else {
      Debug.LogError("Recorder reference is not set in AudioPlayer.");
    }
  }

  public void PlayAudioClip(AudioClip clip) {
    if (_audioSource != null && clip != null) {
      _audioSource.clip = clip;
      _audioSource.Play();
    } else {
      Debug.LogError("AudioSource or AudioClip is null. Cannot play audio.");
    }
  }

  private AudioSource _audioSource;

}