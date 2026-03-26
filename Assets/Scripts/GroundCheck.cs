using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    BoxCollider2D BC2D;
    public bool onGround = false;
    public LayerMask groundLayer;
    public float xWidth = 0.9f;
    public float yDis = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        BC2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGround()
    {
        onGround = Physics2D.BoxCast(BC2D.bounds.center, BC2D.bounds.size * new Vector2(xWidth,1f), 0, Vector2.down,yDis, groundLayer);
    }

    void OnDrawGizmos()
    {
        if (BC2D == null)
        {
            BC2D = GetComponent<BoxCollider2D>();
        }

        if (BC2D == null) return;

        Vector2 colposition = BC2D.bounds.center;
        Vector2 size = BC2D.bounds.size * xWidth;

        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(colposition, size);

        Vector2 censorposition = colposition + Vector2.down * yDis;
        Gizmos.color = onGround ? Color.blue : Color.red;
        Gizmos.DrawWireCube(censorposition, size);

        Gizmos.DrawLine(colposition, censorposition);
    }
}
