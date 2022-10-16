using UnityEngine;

public class Management  : MonoBehaviour
{
    [SerializeField]
    private Transform _left;

    [SerializeField]
    private Transform _right;

    [SerializeField]
    private float _speed;

    private float _currentTime;
    private bool _isMovingForward;
    private float _oneWayTime;

    private void Awake()
    {
        _oneWayTime = Vector3.Distance(_left.position, _right.position) / _speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isMovingForward = !_isMovingForward;
        }

        _currentTime += _isMovingForward ? Time.deltaTime : -Time.deltaTime;
        var progress = Mathf.PingPong(_currentTime, _oneWayTime) / _oneWayTime;
        transform.position = Vector3.Lerp(_left.position, _right.position, progress);
    }
}