using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController controller;
    public float speed;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groudCheck;
    public float groudDistance = 0.4f;
    public LayerMask groudMask;
    bool isGrouded;
    public float jumpHeight =3f;
   

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        isGrouded = Physics.CheckSphere(groudCheck.position, groudDistance, groudMask);
        if (isGrouded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump")&& isGrouded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

    }
}
