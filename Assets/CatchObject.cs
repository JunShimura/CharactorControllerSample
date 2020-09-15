using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CatchObject : MonoBehaviour
{
    public string catchTag = "Catchable";
    public string releaseInput = "Fire1";
    public float releaseForce = 0.1f;
    GameObject cachedObject = null;
    Rigidbody catchedRigidBody = null;
    bool savedIsKinematic;
    private void Update()
    {
        if (cachedObject != null && Input.GetButton(releaseInput))
        {
            cachedObject.transform.SetParent(null);
            catchedRigidBody.isKinematic = savedIsKinematic;
            catchedRigidBody.AddForce(
                (cachedObject.transform.position - this.transform.position).normalized * releaseForce,
                ForceMode.Impulse);
            cachedObject = null;
            catchedRigidBody = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (cachedObject == null && other.gameObject.CompareTag(catchTag))
        {
            cachedObject = other.gameObject;
            cachedObject.transform.SetParent(this.gameObject.transform);
            catchedRigidBody = other.gameObject.GetComponent<Rigidbody>();
            savedIsKinematic = catchedRigidBody.isKinematic;
            catchedRigidBody.isKinematic = true;
        }
    }
}
