using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : Mover
{
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        UpdateMotor(new Vector3(x, y, 0));
    }
    //[SerializeField] private Animator _animator;
    //[SerializeField] private BoxCollider2D boxCollider2D;
    //private Dungeon _playerControlls;
    //private Rigidbody2D _rb;
    //private Vector2 _moveInput;

    //[SerializeField] private float _speed = 6;


    //private void Awake()
    //{
    //    _rb = GetComponent<Rigidbody2D>();
    //    boxCollider2D = GetComponent<BoxCollider2D>();
    //}

    //private void FixedUpdate()
    //{
    //    _rb.velocity = _moveInput * _speed;
    //}

    //private void Update()
    //{
    //    Run();
    //}

    //private void Run()
    //{
    //    if (_rb.velocity.x != 0f)
    //    {
    //        _animator.SetBool("isRunning", true);
    //    }
    //    else
    //    {
    //        _animator.SetBool("isRunning", false);
    //    }

    //    if (_rb.velocity.x > 0)
    //    {
    //        gameObject.transform.localScale = new Vector3(1, 1, 1);
    //    }

    //    else if (_rb.velocity.x < 0)
    //    {
    //        gameObject.transform.localScale = new Vector3(-1, 1, 1);
    //    }
    //}

    //private void OnMove(InputValue inputValue)
    //{
    //    _moveInput = inputValue.Get<Vector2>();
    //}
}
