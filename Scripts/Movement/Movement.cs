using UnityEngine;

public class Movement : MonoBehaviour {

  protected virtual void Awake() {
    GameObject cameraObject = Camera.main.gameObject;
    if (cameraObject == null) {
      Debug.LogErrorFormat("Error: main camera not found");
      return;
    }
    Transform cameraTransform = cameraObject.transform;
    _cameraForward = cameraTransform.forward;
    _cameraForward.y = 0;
    _cameraForward.Normalize();

    _cameraRight = cameraTransform.right;
    _cameraRight.y = 0;
    _cameraRight.Normalize();
  }

  protected Vector3 GetMovementVector() {
    float horizontalAxis = Input.GetAxis("Horizontal");
    float verticalAxis = Input.GetAxis("Vertical");
    Vector3 movement = _cameraRight * horizontalAxis +
     _cameraForward * verticalAxis;
    if (movement.sqrMagnitude > 1f) {
      movement.Normalize();
    }
    return movement;
  }

  private Vector3 _cameraForward;
  private Vector3 _cameraRight;

  protected readonly float _speed = 10f;
}