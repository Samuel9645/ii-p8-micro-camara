using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TVCameraRecorder : MonoBehaviour {
  public delegate void CameraRecordStart();
  public event CameraRecordStart OnCameraRecordStart;
  public delegate void CameraRecordEnd();
  public event CameraRecordEnd OnCameraRecordEnd;
  private void Start() {
    _renderer = GetComponent<Renderer>();
    if (WebCamTexture.devices.Length <= 0) {
      Debug.LogError("No webcam devices found!");
      return;
    }
    Directory.CreateDirectory(_savePath);
    _webcamDevice = WebCamTexture.devices[0];
    Debug.LogFormat("Using webcam device: {0}", _webcamDevice.name);
    _webcamTexture = new WebCamTexture(_webcamDevice.name);
    _originalTexture = _renderer.material.mainTexture;
  }

  private void Update() {
    if (Input.GetKeyDown(_cameraRecordKey)) {
      Material material = _renderer.material;
      if (_webcamTexture.isPlaying) {
        OnCameraRecordEnd?.Invoke();
        _webcamTexture.Stop();
        material.mainTexture = _originalTexture;
        Debug.Log("Webcam stopped.");
      } else {
        OnCameraRecordStart?.Invoke();
        _webcamTexture.Play();
        material.mainTexture = _webcamTexture;
        Debug.Log("Webcam started.");
      }
    }
    if (Input.GetKeyDown(_screenshotKey)) {
      TakeScreenshot();
      Debug.LogFormat("Screenshot taken, saved to {0}", _savePath);
    }
  }

  private void TakeScreenshot() {
    Texture2D snapshot = new(_webcamTexture.width,
    _webcamTexture.height);
    snapshot.SetPixels32(_webcamTexture.GetPixels32());
    snapshot.Apply();
    string path = Path.Combine(_savePath, _captureCounter.ToString() + ".png");
    File.WriteAllBytes(path, snapshot.EncodeToPNG());
    ++_captureCounter;
  }

  private Renderer _renderer;
  private Texture _originalTexture;
  private WebCamDevice _webcamDevice;
  private WebCamTexture _webcamTexture;
  private readonly string _cameraRecordKey = "r";
  private readonly string _screenshotKey = "s";
  private int _captureCounter = 0;
  private readonly string _savePath =
    Path.Combine(Application.dataPath, "snapshots");
}