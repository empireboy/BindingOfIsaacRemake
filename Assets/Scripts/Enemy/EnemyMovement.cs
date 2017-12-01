using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Vector3 velocity = new Vector2();

    private enum _eState     { walk, knockback, changingDirection }
    private enum _eDirection { left, right, up, down }
    private _eState _state = _eState.walk;
    private _eDirection _direction = _eDirection.left;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _bc2d;
    private float _changeDirectionTimer;
    private float _accelerationValue;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveSpeedMax;
    [SerializeField] private float _changeDirectionTimeMin;
    [SerializeField] private float _changeDirectionTimeMax;
    [SerializeField] private float _friction;
    /*[SerializeField] private float _accelerationStartNumber;
    [SerializeField] private float _accelerationPersentage;
    [SerializeField] private float _accelerationDecreaseNumber;*/

    void Start () {
        _rigidbody  = GetComponent<Rigidbody2D>();
        _bc2d = GetComponent<BoxCollider2D>();
        _changeDirectionTimer = randomDirectionTime();
        //_accelerationValue = _accelerationStartNumber;
    }

    private void Update()
    {
        changeDirectionController();
        stateMachine();
        movementController();
    }

    void movementController()
    {
        movementHorizontal();
        movementVertical();
        move();
    }

    void stateMachine()
    {
        // Smooth acceleration
        switch (_state)
        {
            case _eState.walk:
                break;
            case _eState.changingDirection:
                if (_accelerationValue <= 0)
                {
                    randomDirection();
                    _state = _eState.walk;
                }
                break;
        }
    }

    void changeDirectionController()
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _state = _eState.changingDirection;
        _changeDirectionTimer = randomDirectionTime();
    }

    void movementVertical()
    {
        if (getDirectionVertical() == 1)
        {
            velocity.y += _moveSpeed * Time.deltaTime;
            if (velocity.y > _moveSpeedMax)
                velocity.y = _moveSpeedMax;
        }
        else if (getDirectionVertical() == -1)
        {
            velocity.y -= _moveSpeed * Time.deltaTime;
            if (velocity.y < -_moveSpeedMax)
                velocity.y = -_moveSpeedMax;
        }
        else
        {
            if (velocity.y > 0)
            {
                velocity.y -= _friction * Time.deltaTime;
                if (velocity.y < 0) velocity.y = 0;
            }
            else if (velocity.y < 0)
            {
                velocity.y += _friction * Time.deltaTime;
                if (velocity.y > 0) velocity.y = 0;
            }
        }
    }

    void movementHorizontal()
    {
        if (getDirectionHorizontal() == 1)
        {
            velocity.x += _moveSpeed * Time.deltaTime;
            if (velocity.x > _moveSpeedMax)
                velocity.x = _moveSpeedMax;
        }
        else if (getDirectionHorizontal() == -1)
        {
            velocity.x -= _moveSpeed * Time.deltaTime;
            if (velocity.x < -_moveSpeedMax)
                velocity.x = -_moveSpeedMax;
        }
        else
        {
            if (velocity.x > 0)
            {
                velocity.x -= _friction * Time.deltaTime;
                if (velocity.x < 0) velocity.x = 0;
            }
            else if (velocity.x < 0)
            {
                velocity.x += _friction * Time.deltaTime;
                if (velocity.x > 0) velocity.x = 0;
            }
        }
    }

    void move()
    {
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.MovePosition(transform.position + velocity);
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
