using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;


    Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;

    public SpriteRenderer Head;
    public SpriteRenderer Torso;
    public SpriteRenderer Pelvis;
    public SpriteRenderer lShoulder;
    public SpriteRenderer rShoulder;
    public SpriteRenderer lBoot;
    public SpriteRenderer rBoot;



    public List<Sprite> Heads;
    public List<Sprite> Torsos;
    public List<Sprite> Pelvises;


 

    // Start is called before the first frame update
    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (canMove)
            Movement();
       
    }


    void Movement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.A))
            gameObject.transform.rotation = new Quaternion(0, 180, 0, 0);
        else if (Input.GetKey(KeyCode.D))
            gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        if (rb.velocity.magnitude > 0)
        {
            anim.SetBool("Idle", false);
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Idle", true);
            anim.SetBool("Walking", false);
        }
    }



    private void OnCollisionStay2D(Collision2D collision)
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (collision.gameObject.CompareTag("Dummy"))
            {
                collision.gameObject.GetComponent<Dummy>().ChangeClothes();
            }
            if (collision.gameObject.CompareTag("NPC"))
            {
                canMove = false;
                collision.gameObject.GetComponent<NPC>().TriggerDialogue(NPC.timesTalked);

            }
        }

        
       
    }

    


}
