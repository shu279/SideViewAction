using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] LayerMask blockLayer;
    float x;
    public enum DIRECTION_TYPE
    {
        STOP,
        RIGHT,
        LEFT,
    }

    DIRECTION_TYPE direction = DIRECTION_TYPE.STOP;

    Rigidbody2D rigidbody2D;
    float speed;

    Animator animator;

    float jumpPower = 400;
    bool isDead = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        x = Input.GetAxis("Horizontal");//方向キーの取得
        animator.SetFloat("speed", Mathf.Abs(x));

        if (x == 0)
        {
            direction = DIRECTION_TYPE.STOP;
        }
        else if(x > 0)
        {
            direction = DIRECTION_TYPE.RIGHT;
        }
        else if (x < 0)
        {
            direction = DIRECTION_TYPE.LEFT;
        }
        if (IsGround())
        {
 
            if (Input.GetKeyDown("space"))
            {
                Jump();
            }
            else
            {
                animator.SetBool("isJumping", false);
            }
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }
        switch (direction)
        {
            case DIRECTION_TYPE.STOP:
                speed = 0;
                break;
            case DIRECTION_TYPE.RIGHT:
                speed = 3;
                transform.localScale = new Vector3(1, 1, 1);
                break;
            case DIRECTION_TYPE.LEFT:
                speed = -3;
                transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
        rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
    }

    void Jump()
    {
        rigidbody2D.AddForce(Vector2.up * jumpPower);
        animator.SetBool("isJumping", true);
    }

    bool IsGround()
    {
        Vector3 leftStartPoint = transform.position - Vector3.right * 0.2f;
        Vector3 rightStartPoint = transform.position + Vector3.right * 0.2f;
        Vector3 endPoint = transform.position - Vector3.up * 0.3f;
        return Physics2D.Linecast(leftStartPoint, endPoint, blockLayer)
            || Physics2D.Linecast(rightStartPoint, endPoint, blockLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead)
        {
            return;
        }
        if (collision.gameObject.tag=="Trap")
        {
            PlayerDeath();
        }
        if (collision.gameObject.tag == "Finish")
        {
            gameManager.GameClear();
        }
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.GetComponent<ItemManager>().GetItem();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyManager enemy = collision.gameObject.GetComponent<EnemyManager>();
            if (this.transform.position.y + 0.2f > enemy.transform.position.y)
            {
                //上から
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
                Jump();
                enemy.DestroyEnemy();
            }
            else
            {
                //横から
                PlayerDeath();
            }
        }
    }
    void PlayerDeath()
    {
        isDead = true;
        rigidbody2D.velocity = new Vector2(0, 0);
        rigidbody2D.AddForce(Vector2.up * jumpPower);
        animator.Play("GirlDeathAnimation");
        BoxCollider2D boxcollider2D = GetComponent<BoxCollider2D>();
        Destroy(boxcollider2D);
        gameManager.GameOver();
    }

    private Vector3 offset;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if(block.blockKind == BlockKind.Moving)
            {
               if (x == 0)
                {
                    GetComponent<Transform>().position = collision.gameObject.transform.position + offset;
                }
                else
                {
                    offset = GetComponent<Transform>().position - collision.gameObject.transform.position;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.layer == 8)
        {
            Block block = collision.gameObject.GetComponent<Block>();
            if (block.blockKind == BlockKind.Moving)
            {
                offset = GetComponent<Transform>().position - collision.gameObject.transform.position;
            }
        }
    }
}
