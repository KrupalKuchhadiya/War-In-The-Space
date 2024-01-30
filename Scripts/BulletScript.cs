using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "Boundry")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.transform.tag == "Enemy") 
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
