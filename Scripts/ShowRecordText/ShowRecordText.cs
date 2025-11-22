using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public abstract class ShowRecordingText<Recorder> : MonoBehaviour where Recorder : MonoBehaviour {
  public Recorder recorder;

  private void Start() {
    _textComponent = GetComponent<Text>();
    if (recorder != null) {
      SubscribeToRecorderEvents();
    } else {
      Debug.LogError("Recorder reference is not set in ShowRecordingText.");
    }
    HideText();
  }

  protected void ShowText(string textToShow) {
    if (_textComponent != null) {
      _textComponent.enabled = true;
      _textComponent.text = textToShow;
    }
  }

  protected void HideText() {
    if (_textComponent != null) {
      _textComponent.enabled = false;
    }
  }
  abstract protected void SubscribeToRecorderEvents();

  private Text _textComponent;

}