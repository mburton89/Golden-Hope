using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : Character
{
    enum State
    {
        Normal,
        Attack
    }

    private Rigidbody2D _rigidBody2D;
    public float movementSpeed;
    public float maxSpeed;

    private Vector2 movement;
    private int direction = 0;
    public Animator animator;

    private State state = State.Normal;
    public int armor;
    public int maxArmor;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //If it's not the player's turn, exit the function.

        int horizontal = 0;     //Used to store the horizontal move direction.
        int vertical = 0;       //Used to store the vertical move direction.

        //Check if we are running either in the Unity editor or in a standalone build.
#if UNITY_STANDALONE || UNITY_WEBPLAYER

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int)(Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        //Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
			
			//Check if Input has registered more than zero touches
			if (Input.touchCount > 0)
			{
				//Store the first touch detected.
				Touch myTouch = Input.touches[0];
				
				//Check if the phase of that touch equals Began
				if (myTouch.phase == TouchPhase.Began)
				{
					//If so, set touchOrigin to the position of that touch
					touchOrigin = myTouch.position;
				}
				
				//If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
				else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
				{
					//Set touchEnd to equal the position of this touch
					Vector2 touchEnd = myTouch.position;
					
					//Calculate the difference between the beginning and end of the touch on the x axis.
					float x = touchEnd.x - touchOrigin.x;
					
					//Calculate the difference between the beginning and end of the touch on the y axis.
					float y = touchEnd.y - touchOrigin.y;
					
					//Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
					touchOrigin.x = -1;
					
					//Check if the difference along the x axis is greater than the difference along the y axis.
					if (Mathf.Abs(x) > Mathf.Abs(y))
						//If x is greater than zero, set horizontal to 1, otherwise set it to -1
						horizontal = x > 0 ? 1 : -1;
					else
						//If y is greater than zero, set horizontal to 1, otherwise set it to -1
						vertical = y > 0 ? 1 : -1;
				}
			}
			
#endif 
        if (horizontal != 0 || vertical != 0)
        {
            _rigidBody2D.drag = 0f;
            AttemptMove(horizontal, vertical);
            //animator.SetBool("Moving", true);
        }
        else
        {
            _rigidBody2D.drag = 5f;
            //animator.SetBool("Moving", false);
        }

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.magnitude);

        if (movement.x < 0)
        {
            if (movement.y < 0)
            {
                direction = 0;
            }
            else if (movement.y < 0)
            {
                direction = 1;
            }
        }
        else if (movement.x > 0)
        {
            if (movement.y > 0)
            {
                direction = 2;
            }
            else if (movement.y < 0)
            {
                direction = 3;
            }
        }


        switch (state)
        {
            case State.Normal:
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        state = State.Attack;
                    }
                    break;
                }
            case State.Attack:
                {
                    StartCoroutine(Attack());
                    break;
                }
            default:
                {
                    state = State.Normal;
                    break;
                }


        }

        bool attack = Input.GetMouseButtonDown(0);
        //animator.SetBool("Attacking", attack);
        //animator.SetInteger("Direction", direction);
    }

    void FixedUpdate()
    {
        if (_rigidBody2D.velocity.magnitude > (maxSpeed))
        {
            _rigidBody2D.velocity = _rigidBody2D.velocity.normalized * (maxSpeed);
        }
    }

    void AttemptMove(int xDir, int yDir)
    {
        Vector2 direction = new Vector2(xDir, yDir);
        _rigidBody2D.AddForce(direction * movementSpeed);
    }

    IEnumerator Attack()
    {
        //animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.5f);
        //animator.SetBool("Attacking", false);
        state = State.Normal;
    }
    
}
