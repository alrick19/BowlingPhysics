using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float globalScore = 0;
    [SerializeField] private BallController ball;
    [SerializeField] private GameObject pinCollection;
    [SerializeField] private Transform pinAnchor;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();

    }
    private void HandleReset()
    {
        ball.ResetBall();
        SetScore(0);
        SetPins();
    }
    private void SetPins()
    {
        if(pinObjects)
        {
            foreach(Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }

            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection,
                                pinAnchor.transform.position,
                                Quaternion.identity, transform);


        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);
        foreach(FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

    }


    private void IncrementScore()
    {
        SetScore(++globalScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetScore(float score)
    {
        globalScore = score;
        scoreText.text = $"Score: {globalScore}";
    }
}
