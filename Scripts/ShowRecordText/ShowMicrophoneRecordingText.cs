using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowMicrophoneRecordingText : ShowRecordingText<MicrophoneRecorder> {

  protected override void SubscribeToRecorderEvents() {
    recorder.OnRecordStart += () => ShowText("Microphone Recording...");
    recorder.OnRecordEnd += clip => HideText();
  }
}