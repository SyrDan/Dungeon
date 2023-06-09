using UnityEngine;

public abstract class Mover : Fighter
{
    public BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    protected float ySpeed = 2.4f;
    protected float xSpeed = 3f;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        moveDelta = new Vector3 (input.x * xSpeed, input.y * ySpeed, 0);

        if (moveDelta.x > 0) 
        {
            transform.localScale = Vector3.one;
        }
        if (moveDelta.x < 0)
        {
            transform .localScale = new Vector3 (-1,1,1);
        }

        moveDelta += pushDirection;

        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2 (0,moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Enemy"));
        
        if (hit.collider == null)
        {
        transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }


        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0 ), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Enemy"));
        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0 , 0);
        }
    }
}
