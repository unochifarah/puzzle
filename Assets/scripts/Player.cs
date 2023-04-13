using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    [SerializeField] private float speed;
    [SerializeField] private float Jump;
    [SerializeField] private LayerMask groundlayer;
        [SerializeField] private LayerMask Waterlayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake() 
    {
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       boxCollider = GetComponent<BoxCollider2D>();
     

    }

    // Update is called once per frame
    private void Update()
    {
        
        float HorizontalInput = Input.GetAxis("Horizontal");
         body.velocity = new Vector2(HorizontalInput  * speed, body.velocity.y);
        body.velocity = new Vector2(HorizontalInput  * speed, body.velocity.y);
        
        if (HorizontalInput > 0.02f)
            transform.localScale =new Vector3(2, 2, 1);
        else if (HorizontalInput < -0.02f)
            transform.localScale = new  Vector3(-2, 2, 1);

         if (Input.GetKey(KeyCode.Space) && isGrounded())
         jump();

         anim.SetBool("run", HorizontalInput != 0);
         anim.SetBool("grounded", isGrounded());
         
    }

     private void jump()
{
    body.velocity = new Vector2(body.velocity.x, Jump);
    anim.SetTrigger("jump");
}

       private void OnCollisionEnter2D(Collision2D collision)
       {
         
       
       }

       private bool isGrounded()
       {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundlayer);
        return raycastHit.collider != null;
       }
        
            
    }
    