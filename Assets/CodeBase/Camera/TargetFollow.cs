using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate() =>
        transform.position = new Vector3(_target.position.x, transform.position.y, transform.position.z);
}