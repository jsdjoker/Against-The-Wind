using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] float checkpointtimExtension = 4f;

    GameManager gameManager;

    const string playerstring = "Player";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerstring))
        {
            gameManager.IncreaseTime(checkpointtimExtension);
        }
    }
}
