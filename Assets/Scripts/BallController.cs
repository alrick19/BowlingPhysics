using System;
using UnityEngine;
using UnityEngine.Events;


public class BallController : MonoBehaviour
{
    [SerializeField] private float force = 1f;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform ballAnchor;
    [SerializeField] private Transform launchIndicator;

    private Rigidbody ballRB;
    private bool isBallLaunched;

    // Update is called once per frame

    void Start()
    {
        // Grabbing a reference to RigidBody
        ballRB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        // Add a listener to the OnSpacePressed event.
        // When the space key is pressed the LaunchBalllMethod will be called.
        inputManager.OnSpacePressed.AddListener(LaunchBall);

        ResetBall();


    }

    public void ResetBall()
    {
        isBallLaunched = false;
        ballRB.isKinematic = true;

        transform.parent = ballAnchor;

        transform.localPosition = Vector3.zero;
        launchIndicator.transform.localPosition = Vector3.zero;
        // launchIndicator.transform.localPosition = new Vector3(0, 0, 3f);  
        launchIndicator.gameObject.SetActive(true);

        
        Debug.Log($"[After Reset] LaunchIndicator Active: {launchIndicator.gameObject.activeSelf}");
        Debug.Log($"[After Reset] LaunchIndicator Position: {launchIndicator.transform.position}");
    }

    private void LaunchBall()
    {
        if(isBallLaunched)
            return;

        isBallLaunched = true;
        transform.parent = null;
        ballRB.isKinematic = false;
        ballRB.AddForce(launchIndicator.forward * force, ForceMode.Impulse);
        launchIndicator.gameObject.SetActive(false);
    }
}
