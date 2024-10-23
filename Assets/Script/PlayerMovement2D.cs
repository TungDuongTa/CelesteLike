//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerMovement2D : MonoBehaviour
//{
//    [Header("Variables")]
//    public float moveSpeed = 5;
//    public float jumpForce = 10f;
//    public LayerMask groundMask;

//    public Transform groundPos;

//    [Header("Hair")]
//    public Transform hairAnchor;
//    public GameObject hair;

//    public hairDelegate hairGravity;
//    public delegate void hairDelegate(float newGravity);

//    [Header("Private")]
//    Rigidbody2D rb;
//    Vector2 input;
//    bool isGrounded;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();

//        CreateHair();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        #region Basic Movement
//        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //Get Input

//        isGrounded = Physics2D.OverlapCircle(groundPos.position, .1f, groundMask); //Check Grounded

//        if (Input.GetButtonDown("Jump") && isGrounded) //Jump
//        {
//            rb.velocity = Vector2.up * jumpForce;
//        }

//        rb.velocity = new Vector2(input.x * moveSpeed, rb.velocity.y); //Apply velocity
//        #endregion

//        //Apply Hair Gravity
//        if (isGrounded)
//        {
//            hairGravity?.Invoke(-.1f);
//        }
//        else
//        {
//            hairGravity?.Invoke(-.025f);
//        }

//        #region Flip Player
//        if (rb.velocity.x > 0)
//        {
//            transform.localScale = new Vector3(1, 1, 1);
//        }
//        else if (rb.velocity.x < 0)
//        {
//            transform.localScale = new Vector3(-1, 1, 1);
//        }
//        #endregion
//    }

//    public void CreateHair()
//    {
//        GameObject obj = Instantiate(hair);
//        foreach (Transform child in obj.transform)
//        {
//            child.GetComponent<Hair>().InitHair(this, hairAnchor);
//        }
//    }
//}