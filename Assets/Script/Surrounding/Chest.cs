using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite _chestOpened;
    public int coinAmount = 5;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = _chestOpened;
            GameManager.Instance.ShowText("+ " + coinAmount + " coins!", 25, Color.yellow, transform.position, Vector3.up * 30, 1.2f);
        }
    }
}
