using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        characterController.Move(new Vector3(hInput, 0, 0));
    }
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.CompareTag("Catchable"))
        {
            other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }
}
