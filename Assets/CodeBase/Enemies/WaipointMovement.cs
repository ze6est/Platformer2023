using UnityEngine;

public class WaipointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _target;

    private void Awake()
    {
        int pointsCount = _path.childCount;

        _points = new Transform[pointsCount];

        for (int i = 0; i < pointsCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Start()
    {
        SetTarget();
        SetDirectionMovement();
    }

    private void Update()
    {
        Vector3 targetPositionX = new Vector3(_target.position.x, transform.position.y);
        Vector3 direction = Vector3.MoveTowards(transform.position, targetPositionX, _speed * Time.deltaTime);

        transform.position = new Vector3(direction.x, transform.position.y);

        if (transform.position.x == _target.position.x)
            MoveToNextTarget();
    }
    private void MoveToNextTarget()
    {
        _currentPoint++;

        if (_currentPoint == _points.Length)
            _currentPoint = 0;

        SetTarget();
        SetDirectionMovement();
    }

    private void SetDirectionMovement()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.localScale = new Vector3(direction.x, 1, 1);
    }

    private void SetTarget() =>
        _target = _points[_currentPoint];
}