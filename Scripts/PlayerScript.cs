using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Variables For Follow The Mouse Arrow
    Vector2 ScreenSize;
    float width_Screen = Screen.width;
    float height_Screen = Screen.height;
    float speed = 5f;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject SpawnObject;
    // Start is called before the first frame update
    void Start()
    {
        ScreenSize = Camera.main.ScreenToWorldPoint(new Vector2(width_Screen, height_Screen));
        StartCoroutine(SpawnBullet(0.2f));
    }
    
    // Update is called once per frame
    void Update()
    {
        //Player Follow The Arrow
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

            float width_PlayerSprite = transform.localScale.x / 2;
            float height_PlayerSprite = transform.localScale.y / 2;

            float width_Screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - width_PlayerSprite - 0.25f;
            float height_Screen = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - height_PlayerSprite - 0.4f;

            float clamped_X = Mathf.Clamp(mousePosition.x, -width_Screen, width_Screen);
            float clamped_Y = Mathf.Clamp(mousePosition.y, -height_Screen, height_Screen / 128);

            transform.position = new Vector3(clamped_X, clamped_Y, 0f);
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            float width_Screen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
            float height_Screen = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);
            transform.Translate(movement * speed * Time.deltaTime);

            float width_PlayerSprite = transform.localScale.x / 2;
            float height_PlayerSprite = transform.localScale.y / 2;

            float clampedX = Mathf.Clamp(transform.position.x, -width_Screen + width_PlayerSprite + 0.25f, width_Screen - width_PlayerSprite - 0.25f);
            float clampedY = Mathf.Clamp(transform.position.y, -height_Screen + height_PlayerSprite + 0.4f,(height_Screen - height_PlayerSprite - 0.4f)/ 128);

            transform.position = new Vector3(clampedX, clampedY, 0f);
        }

        //Spawn The Bullet
       
    }

    IEnumerator SpawnBullet(float Time)
    {
        yield return new WaitForSeconds(Time);
        GameObject G = Instantiate(Bullet);
        //G.gameObject.transform.parent = SpawnObject.gameObject.transform;
        G.gameObject.transform.position = SpawnObject.gameObject.transform.position;
        StartCoroutine(SpawnBullet(0.2f));
    }
}