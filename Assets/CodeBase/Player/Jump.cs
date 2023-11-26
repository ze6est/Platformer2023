using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerCollisionDetector))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _force;

    private Rigidbody2D _rigidbody;
    private PlayerCollisionDetector _detector;
    private bool _isGround;

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _detector = GetComponent<PlayerCollisionDetector>();
    }

    private void OnEnable() => 
        _detector.GroundTouched += OnGroundTouched;

    private void OnDisable() => 
        _detector.GroundTouched -= OnGroundTouched;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && _isGround))
            MakeJump(Vector3.up);
    }

    private void OnGroundTouched() => 
        _isGround = true;

    private void MakeJump(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _force);
        _isGround = false;
    }
}