using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.transform.tag == "boundry_Down")
        {
            Destroy(this.gameObject);
        }
    }
}
