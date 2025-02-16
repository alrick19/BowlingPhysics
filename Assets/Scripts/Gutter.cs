using UnityEngine;

public class Gutter : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider triggeredBody)
    {
        // get ball rigid body
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // store velocity magnitude
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // reset both linear and angular 0> ball rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // add force in forward direction of the gutter
        ballRigidBody.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }
}
