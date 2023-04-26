using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    public float triggerLenght = 1f;
    private float chaseLenght = 5f;
    private bool chasing;
    private bool collifingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPos;

    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.Instance.player.transform;
        startingPos = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>(); 
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(playerTransform.position, startingPos) < chaseLenght)
        {
            if (Vector3.Distance(playerTransform.position, startingPos) < triggerLenght)
            {
                chasing = true;
            }

            if ( chasing ) 
            {
                if (!collifingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
                else
                {
                    UpdateMotor(startingPos - transform.position);
                }
            }    
            else
            {
                UpdateMotor(startingPos - transform.position);
                    chasing = false;
            }
        }

        collifingWithPlayer = false;
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collifingWithPlayer = true;
            }

            hits[i] = null;

        }
    }

    protected override void Death()
    {
        Destroy(gameObject);

    }
}
