using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerInputs PlayerInput;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed;




    // Start is called before the first frame update
    void Awake()
    {
        PlayerInput = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveInput = PlayerInput.Movement.Move.ReadValue<Vector2>();
        rb.velocity = moveInput * speed;


        if (moveInput.x == -1)
            gameObject.transform.rotation = new Quaternion(0,180,0,0);
        else if(moveInput.x == 1)
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


    private void OnEnable()
    {
        PlayerInput.Enable();
    }

    private void OnDisable()
    {
        PlayerInput.Disable();
    }

}
