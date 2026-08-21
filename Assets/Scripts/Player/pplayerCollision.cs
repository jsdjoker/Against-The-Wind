using UnityEngine;

public class pplayerCollision : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    float coolDownTimer = 0f;

    LevelGenerator levelGenerator;

    private void Update()
    {
        coolDownTimer += Time.deltaTime;
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (coolDownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);

        anim.SetTrigger("Hit");

        coolDownTimer = 0f;
    }
}
