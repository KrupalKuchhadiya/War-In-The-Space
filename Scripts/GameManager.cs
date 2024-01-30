using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    //Enemy Spwan & Parent Variables
    [SerializeField] GameObject Enemy1_Prefeb;
    [SerializeField] List<GameObject> Enemy_Spwan_Position;
    [SerializeField] GameObject First_Spwan_Position;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Spwaned();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Institate,Position & Parent To Enemy
    public void Enemy_Spwaned()
    {
        for (int i = 0; i < Enemy_Spwan_Position.Count; i++)
        {
            GameObject G = Instantiate(Enemy1_Prefeb, First_Spwan_Position.transform);
            G.gameObject.transform.parent = Enemy_Spwan_Position[i].transform;
            G.transform.DOMove(new Vector3(Enemy_Spwan_Position[i].transform.position.x, Enemy_Spwan_Position[i].transform.position.y, Enemy_Spwan_Position[i].transform.position.z), 0.5f);
        }
    }
}
