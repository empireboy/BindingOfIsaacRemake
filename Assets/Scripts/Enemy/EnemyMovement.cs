using UnityEngine;

// Movement fix

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class EnemyMovement : MonoBehaviour {
    private enum _eState     { walk, knockback, changingDirection }
    private enum _eDirection { left, right, up, down }
    private _eState _state = _eState.walk;
    private _eDirection _direction = _eDirection.left;
    private Rigidbody2D _rigidbody;
    private float _changeDirectionTimer;
    private float _accelerationValue;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _changeDirectionTimeMin;
    [SerializeField] private float _changeDirectionTimeMax;
    [SerializeField] private Boundary _boundary;
    [SerializeField] private float _accelerationStartNumber;
    [SerializeField] private float _accelerationPersentage;
    [SerializeField] private float _accelerationDecreaseNumber;

    void Start () {
        _rigidbody = GetComponent<Rigidbody2D>();
        _changeDirectionTimer = randomDirectionTime();
        _accelerationValue = _accelerationStartNumber;
    }

    private void Update()
    {
        // Check for direction change
        if (_changeDirectionTimer > 0)
        {
            _changeDirectionTimer--;
        }
        else
        {
            // Change direction
            _state = _eState.changingDirection;
            _changeDirectionTimer = randomDirectionTime();
        }

        // Smooth acceleration
        switch (_state)
        {
            case _eState.walk:
                _accelerationValue = Mathf.Lerp(_accelerationValue, 1, _accelerationPersentage * Time.deltaTime);
                break;
            case _eState.changingDirection:
                _accelerationValue -= _accelerationDecreaseNumber;
                if (_accelerationValue <= 0)
                {
                    randomDirection();
                    _state = _eState.walk;
                }
                break;
        }
    }

    void FixedUpdate () {
        _rigidbody.velocity = new Vector2(getDirectionHorizontal(), getDirectionVertical()) * _moveSpeed * Time.deltaTime * _accelerationValue;
        /*_rigidbody.position = new Vector2
        (
            Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax),
            Mathf.Clamp(_rigidbody.position.y, _boundary.yMin, _boundary.yMax)
        );*/
    }

    private float getDirectionHorizontal()
    {
        switch (_direction) {
            case _eDirection.left: return -1f;
            case _eDirection.right: return 1f;
        }

        return 0;
    }

    private float getDirectionVertical()
    {
        switch (_direction)
        {
            case _eDirection.up: return -1f;
            case _eDirection.down: return 1f;
        }

        return 0;
    }

    private float randomDirectionTime()
    {
        return Random.Range(_changeDirectionTimeMin, _changeDirectionTimeMax) * Time.deltaTime;
    }

    private void randomDirection()
    {
        int randomDirectionNumber = Random.Range(0, 4);
        switch(randomDirectionNumber)
        {
            case 0: _direction = _eDirection.left; break;
            case 1: _direction = _eDirection.right; break;
            case 2: _direction = _eDirection.up; break;
            case 3: _direction = _eDirection.down; break;
        }
    }
}
