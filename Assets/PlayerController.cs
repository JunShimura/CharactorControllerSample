using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float speed = 0.1f;
    Vector3 gravity;
    Vector3 moveVector;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravity = Physics.gravity;
        moveVector = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        moveVector.y = 0;
        moveVector.z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (!characterController.isGrounded)
        {
            moveVector += gravity * Time.deltaTime;
        }
        characterController.Move(moveVector);
    }
}
