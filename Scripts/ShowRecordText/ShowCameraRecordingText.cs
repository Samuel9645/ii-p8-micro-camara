using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ShowCameraRecordingText : ShowRecordingText<TVCameraRecorder> {
  protected override void SubscribeToRecorderEvents() {
    recorder.OnCameraRecordStart += () => ShowText("Camera Recording...");
    recorder.OnCameraRecordEnd += HideText;
  }
}