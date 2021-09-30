using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static bool canMove = true;
    public int money;
    public Text moneyTxt;
    public CanvasGroup Wardrobe;

    [Space]

    Vector2 movement;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;

    [Space]
    public SpriteRenderer Head;
    public SpriteRenderer Torso;
    public SpriteRenderer Pelvis;



    public List<Sprite> allClothes;
    


 

    // Start is called before the first frame update
    void Awake()
    {
        allClothes = new List<Sprite>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        allClothes.Add(Head.sprite);
        allClothes.Add(Torso.sprite);
        allClothes.Add(Pelvis.sprite);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moneyTxt.text = "$" + money.ToString();


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

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
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


    public void UpdateClothes()
    {

    }





    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if (Input.GetKey(KeyCode.F))
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
            if (collision.gameObject.CompareTag("Wardrobe"))
            {
               // collision.gameObject.GetComponent<Wardrobe>().GetClothes();
                canMove = false;
                Wardrobe.alpha = 1;
                Wardrobe.blocksRaycasts = true;
                Wardrobe.interactable = true;
            }
        }
    }




}
