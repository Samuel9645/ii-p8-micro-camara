using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodyMovement : Movement {
  private void FixedUpdate() {
    Vector3 movement = GetMovementVector();
    _rigidBody.AddForce(
      Time.fixedDeltaTime * _speed * _rigidBody.mass *
        movement,
      ForceMode.VelocityChange
    );
  }

  private void Start() {
    _rigidBody = GetComponent<Rigidbody>();
    if (_rigidBody == null) {
      Debug.LogErrorFormat(
        "Error: rigidbody component not found on {0}",
        gameObject.name
      );
    }
  }

  private Rigidbody _rigidBody;
}