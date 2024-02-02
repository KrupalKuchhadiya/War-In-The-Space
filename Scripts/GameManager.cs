using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    //Enemy Spwan & Parent Variables
    [SerializeField] GameObject prefeb_Enemy1, prefeb_Enemy2;
    [SerializeField] List<GameObject> Enemy_Spwan_Position;
    [SerializeField] GameObject First_Spwan_Position;
    [SerializeField] GameObject UpObject, DownObject;
 

    // Start is called before the first frame update
    void Start()
    {
        Vector2 pos = new Vector2(Screen.width, Screen.height);
        Vector2 ScreenSize = Camera.main.ScreenToWorldPoint(pos);
        UpObject.GetComponent<BoxCollider2D>().size = new Vector2(ScreenSize.x * 2, 1);
        UpObject.transform.position = new Vector2(0, ScreenSize.y + UpObject.GetComponent<BoxCollider2D>().size.y / 2);

        DownObject.GetComponent<BoxCollider2D>().size = new Vector2(ScreenSize.x * 2, 1);
        DownObject.transform.position = new Vector2(0, -ScreenSize.y - DownObject.GetComponent<BoxCollider2D>().size.y / 2);
        spawn_Enemy();
        StartCoroutine(enemy_BombSpwan(0.5f));
    }

    // Institate,Position & Parent To Enemy
    public void spawn_Enemy()
    {
        for (int i = 0; i < Enemy_Spwan_Position.Count; i++)
        {
            GameObject G = Instantiate(prefeb_Enemy1, First_Spwan_Position.transform);
            G.gameObject.transform.parent = Enemy_Spwan_Position[i].transform;
            G.transform.DOMove(new Vector3(Enemy_Spwan_Position[i].transform.position.x, Enemy_Spwan_Position[i].transform.position.y, Enemy_Spwan_Position[i].transform.position.z), 0.5f);
        }
       
    }

 

    IEnumerator enemy_BombSpwan(float Time)
    {
        yield return new WaitForSeconds(Time);
        Instantiate(prefeb_Enemy2, new Vector3(Random.Range(-PlayerScript.Instance.ScreenSize.x, PlayerScript.Instance.ScreenSize.x), Random.Range(6, 7), 0), Quaternion.identity);
        StartCoroutine(enemy_BombSpwan(1f));
    }
}
