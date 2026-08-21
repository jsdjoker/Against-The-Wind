using UnityEngine;

public class Coin : PickUp
{

    [SerializeField] int scoreAmount = 50;

    ScoreManager scoreManager;

    public void Init(ScoreManager scoreManager )
    {
       this.scoreManager = scoreManager;
    }
    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(scoreAmount);
    }
}
