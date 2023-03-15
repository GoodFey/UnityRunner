using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _stepSize;

    private int _maxHeight = 3;
    private int _minHeight = -3;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }
    private void Update()
    {
        if (_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
            SetNewTargetPosition(_stepSize);
    }
    public void TryMoveDown()
    {
        if(_targetPosition.y > _minHeight)
            SetNewTargetPosition(-_stepSize);
    }
    private void SetNewTargetPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
