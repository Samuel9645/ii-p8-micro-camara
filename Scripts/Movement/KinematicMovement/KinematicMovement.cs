using UnityEngine;

public class KinematicMovement : Movement {
  private void Update() {
    Vector3 movement = GetMovementVector();
    transform.Translate(
      Time.deltaTime * _speed * movement,
      Space.World
    );
  }
}
