using UnityEngine;

public class MicrophoneRecorder : MonoBehaviour {
  public delegate void RecordStart();
  public event RecordStart OnRecordStart;
  public delegate void RecordEnd(AudioClip recordedClip);
  public event RecordEnd OnRecordEnd;

  private void Awake() {
    if (Microphone.devices.Length <= 0) {
      Debug.LogError("No microphone devices found!");
      return;
    }
    _microphoneDeviceName = Microphone.devices[0];
    Debug.LogFormat("Using microphone device: {0}", _microphoneDeviceName);
  }

  private void Update() {
    if (Input.GetKeyDown(_recordKey) && !_recording) {
      _recording = true;
      Debug.Log("Recording started.");
      _recordedClip = Microphone.Start(_microphoneDeviceName, false, 300, 44100);
      OnRecordStart?.Invoke();
    } else if (Input.GetKeyDown(_recordKey)) {
      Microphone.End(_microphoneDeviceName);
      Debug.Log("Recording ended.");
      OnRecordEnd?.Invoke(_recordedClip);
      _recording = false;
    }

  }

  private string _microphoneDeviceName;
  private AudioClip _recordedClip;
  private readonly string _recordKey = "r";
  private bool _recording = false;

}
