using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    GameObject player;
    BoxCollider2D B2D;
    PlayerController controller;
    float fadeTime = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject == null) return;

        if (col.gameObject.CompareTag("Player"))
        {
            controller = col.gameObject.GetComponent<PlayerController>();
            float speed = controller.currentPlayerSpeed;

            if (speed <= 5.0f)
            {
                //playerlife--;
            }
            else if (speed >= 5.0f)
            {
                Destroy(GetComponent<Rigidbody2D>());
                GetComponent<BoxCollider2D>().enabled = false;

                Rigidbody rbody = gameObject.AddComponent<Rigidbody>();

                rbody.AddForce(new Vector3(5f, 5f, -10), ForceMode.Impulse);
                rbody.AddTorque(new Vector3(0, 0, 180), ForceMode.Impulse);

                Destroy(gameObject, fadeTime);

                this.enabled = true;
            }
        }
    }

}
