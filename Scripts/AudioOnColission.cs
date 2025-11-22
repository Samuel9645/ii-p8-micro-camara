using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioOnColission : MonoBehaviour {

  private void Start() {
    _audioSource = GetComponent<AudioSource>();
  }
  private void OnCollisionEnter(Collision collision) {
    if (_audioSource != null && collision.gameObject.CompareTag(tag)) {
      _audioSource.Play();
    }
  }

  private AudioSource _audioSource;

}
