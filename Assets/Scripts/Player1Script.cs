using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class Player1Script : MonoBehaviour {

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float rotateSpeed = 5.0f;
    public float gravity = 9.81f;
    Vector3 moveDirection = Vector3.zero;

    public int type = 0;

    // Score stuff
    public int score;
    public GameObject uiScore;

    CharacterController cc;

    public Rigidbody projectilePrefab;
    public Transform projectileSpawnPoint;
    public float fireSpeed = 50.0f;

	// Use this for initialization
	void Start () {
        // Grab a component and keep a reference to it
        cc = GetComponent<CharacterController>();
        if (!cc)
            Debug.Log("CharacterController does not exist.");

        uiScore = GameObject.Find("Player1 Camera/Canvas (P1)/Score (P1)");
    }
	
	// Update is called once per frame
	void Update () {
        // SimpleMove()
	    if (type == 1)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

            Vector3 forward = transform.TransformDirection(Vector3.forward);

            float curSpeed = speed * Input.GetAxis("Vertical");

            cc.SimpleMove(forward * curSpeed);
        }
        // Move()
        else if (type == 0)
        {
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));

            if (cc.isGrounded)
            {
                // Strafe
                //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));

                transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

                moveDirection = transform.TransformDirection(moveDirection);

                moveDirection *= speed;

                if(Input.GetButtonDown("Jump"))
                    moveDirection.y = jumpSpeed;
            }

            moveDirection.y -= gravity * Time.deltaTime;

            cc.Move(moveDirection * Time.deltaTime);
            /* // if character's y pos goes less than 113 (water level)
            if (cc.transform.position.y < 113)
            {
                // tint camera blue
            }*/
        }

        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Key Press Stuff
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Pew Pew");
            if (projectilePrefab)
            {
                Rigidbody temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, transform.rotation) as Rigidbody;

                temp.AddForce(Vector3.forward * fireSpeed, ForceMode.Impulse);
            }
            else
                Debug.Log("No prefab found.");
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {

        }

        // Check CollisionFlags on CharacterController
        if (cc.collisionFlags == CollisionFlags.None)
        {
            Debug.Log("Character is in the air.");
        }

    } // Update

    // Needs a Collider attached to GameObject
    // 'Is Trigger' must be checked on Collider.
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger happened.");

        // If character runs into an object with the tag 'Collectable', destroy the Collectable object
        // Add 50 to score
        // Update score on the UI
        if (c.gameObject.tag == "Collectable")
        {
            Destroy(c.gameObject);
            score += 50;
            uiScore.GetComponent<Text>().text = "Score: " + score;
        }
    }

    void OnTriggerStay(Collider c)
    {
        //Debug.Log("Trigger stay happened.");
    }

    void OnTriggerExit(Collider c)
    {
        Debug.Log("Trigger exit happened.");
    }

    void OnCollisionEnter(Collision c)
    {
       // Debug.Log("Character hit" + c.gameObject.name);
    }

    void OnControllerColliderHit(ControllerColliderHit c)
    {
        //Debug.Log("Controller hit" + c.gameObject.name);
    }
}
