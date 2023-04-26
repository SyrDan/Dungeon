using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    public float pushRecoverySpeed = 0.2f;

    protected float immuneTime = 1.0f;
    protected float lastImune;

    protected Vector3 pushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImune > immuneTime) 
        {
            lastImune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.Instance.ShowText("Damage " + dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {

    }
}
