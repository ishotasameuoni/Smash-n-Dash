using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 playerPosition;
    GameObject player;
    public GameObject Goal;
    float limitedX;
    float limitedY;
    Vector3 currentPosition;
    //public GameObject[] backgrounds;
    //public float bgWidth = 17.5f;
    public GameObject scene;
    public float scrollSpeed = 0.0005f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        playerPosition = player.transform.position;

        scene.transform.localPosition = new Vector2(playerPosition.x, 0);
        
        //MoveBackGround();


        if (Goal == null)
        {
            Goal = GameObject.FindWithTag("Goal");
        }

        if (player == null) return;

        else
        {
            //プレイヤ―の慣性やジャンプ力に応じて変動させる必要あり(今後のゲームデザイン次第で壁を設けてカメラを行けなくするのかそれとも変数で動きを制御するのか）

            limitedX = Mathf.Clamp(playerPosition.x, 0f, Goal ? Goal.transform.position.x : 30f);
            limitedY = Mathf.Clamp(playerPosition.y, 0f, Goal ? Goal.transform.position.y : 20f);
            Vector3 limitedPosition = new Vector3(limitedX, limitedY, -10);
            transform.position = limitedPosition;
        }

    }

    //void MoveBackGround()
    //{

    //    foreach (GameObject bg in backgrounds)
    //    {
    //        float bgX = bg.transform.position.x;
    //        float gap = bgX - currentPosition.x;

    //        if (gap < -bgWidth)
    //        {
    //            bg.transform.position += new Vector3(bgWidth * 2, 0, 0);
    //        }
    //        else if (gap > bgWidth)
    //        {
    //            bg.transform.position -= new Vector3(bgWidth * 2, 0, 0);
    //        }

    //    }
    //}


}
