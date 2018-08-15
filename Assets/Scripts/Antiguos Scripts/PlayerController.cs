using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

#region Public Variables
    [Header("\t--Public Variables--")]
    public float movementSpeed = 10;
    public float rotationSpeed = 5;
    public float gravityMultiplier = 1.0f;
    public float gravity = 10.0f;
    public float verticalVelocity;
    public float jumpForce = 7.0f;

    #endregion
    //Player Movement
    private CharacterController characterController;
    private float x_input;
    private float z_input;
    private float newAngle;
    private Vector3 movement;
    private Vector3 direction;
    private CollisionFlags colisionesDelPlayer = CollisionFlags.None;

    public Quaternion from = Quaternion.Euler(0f, 0f, 0f);
    public Quaternion to = Quaternion.Euler(0f, 90f, 0f);

    void Start ()
    {
        characterController = GetComponent<CharacterController>();
    }
	

	void Update ()
    {
        if (!GameManager.Instance.CheckIfPlayerIsDead())
        {
            x_input = Input.GetAxis("Horizontal");
            z_input = Input.GetAxis("Vertical");

            movement = new Vector3(x_input, 0f, z_input);
            movement = transform.TransformDirection(movement);

            //transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, z_input));

            /*if (Input.GetKeyDown(KeyCode.A))
            {
                transform.rotation = Quaternion.Lerp(from, to, Time.time * rotationSpeed);
            } else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.rotation = Quaternion.Lerp(to, from, Time.time * rotationSpeed);
            }*/


            //FORMA 1--------------- rota muy bien, pero se mueve al rotar
            /*if (movement != Vector3.zero)
            {
                if (Vector3.Angle(transform.forward, direction) > 179)
                {
                    // This will cause us to always turn to the right to go the opposite direction
                    direction = transform.TransformDirection(new Vector3(.01f, 0, -1));
                }
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), 90f * Time.deltaTime);

                Vector3 moveDirection = transform.forward;
                moveDirection.y -= gravity * Time.deltaTime;
            }*/
            //-----------------------------

            //FORMA 2-------------- rota en el sitio, pero rota TANTO que gira
            /*if (movement != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(movement, transform.up);
            movement *= movementSpeed;*/

            if (Input.GetKey(KeyCode.A))
            {
                this.transform.rotation *= Quaternion.Euler(0f, -2f, 0f);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.rotation *= Quaternion.Euler(0f, 2f, 0f);
            }

            movement *= movementSpeed;
            //characterController.Move((movement + moveDirection) * Time.deltaTime);
            //characterController.Move((movement + moveVector)  * Time.deltaTime);
            //--------------------------------
            //transform.LookAt(movement, Vector3.up);

            if (characterController.isGrounded)
            {
                verticalVelocity = -gravity * Time.deltaTime;
                /*if (Input.GetAxis("Jump") > 0)
                {
                    verticalVelocity = jumpForce;
                }*/
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            Vector3 moveVector = new Vector3(0, verticalVelocity, 0);
            /*Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;
            colisionesDelPlayer = characterController.collisionFlags;

            movement *= movementSpeed;*/
            characterController.Move((movement + moveVector) * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.E))
            {
                GameManager.Instance.ShowVictoryScreen();
            }
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (colisionesDelPlayer == CollisionFlags.Below)
            return;

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic)
            return;

        if (hit.gameObject.tag == "Enemy")
        {
            if (!GameManager.Instance.checkpointPassed)
            {
                GameManager.Instance.ShowDefeatScreen();
            }
            else
            {
                characterController.Move(GameManager.Instance.GetSpawnPosition());
                Debug.Log("current position" + GameManager.Instance.GetSpawnPosition());
            }
        }
        //body.AddForceAtPosition(-hit.normal * weight, hit.point);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Goal")
        {
            Debug.Log("Victory!");
            GameManager.Instance.ShowVictoryScreen();
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.Instance.GameOver();
        }
    }*/
}
