using System;
using UnityEngine;
using UnityEngine.Events;


public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;

    private Rigidbody ballRB;
    private bool isBallLaunched;

    // Update is called once per frame
    void Update()
    {
        // Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();

        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the LaunchBalllMethod will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);
    }

    private void LaunchBall()
    {
        if(!isBallLaunched)
            return;

        isBallLaunched = true;
        ballRB.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
