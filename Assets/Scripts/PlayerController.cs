using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    static int playerlife = 5; 
    float elapsedtime = 0.0f;
    float move = 0.0f;
    float minPlayerSpeed = 1.0f;
    public float maxPlayerSpeed = 15.0f;
    public float currentPlayerSpeed;
    public float targetTime = 15.0f;
    bool jump;


    //bool isMoving = true; //後のジャンプ後の処理で使う予定
    Rigidbody2D rbody;
    SpriteRenderer spriteX;

    GroundCheck GroundChecker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteX = GetComponent<SpriteRenderer>();
        GroundChecker = GetComponentInChildren<GroundCheck>();

    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if (move != 0.0f)
        {
            elapsedtime += Time.deltaTime;
            float TimeRatio = Mathf.Clamp01(elapsedtime / targetTime);
            currentPlayerSpeed = Mathf.Lerp(minPlayerSpeed, maxPlayerSpeed, TimeRatio);
        }
        else
        {
            elapsedtime--;
            if(elapsedtime < 0.0f) elapsedtime = 0.0f;
        }
        //Debug.Log(GroundChecker.onGround);
        GroundChecker.OnGround();

        // moveがマイナスならtrue、プラスならfalseになる

        if (move != 0)
        {
            spriteX.flipX = (move < 0);
        }

        jump = Input.GetKeyDown(KeyCode.Space);
        if (jump && GroundChecker.onGround)
        {
            rbody.AddForce(new Vector3(move, 5.0f), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2(move * currentPlayerSpeed, rbody.linearVelocity.y);
    }

}
