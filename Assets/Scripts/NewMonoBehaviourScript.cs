using UnityEngine;

public class PlayerFallGameOver : MonoBehaviour
{
    [Header("Game Over Settings")]
    public Animator playerAnimator;
    public string fallAnimationName = "FallDown";
    public GameObject gameOverUI;

    private bool isGameOver = false;
    private CharacterController characterController;

    private void Start()
    {
        // 获取组件引用
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();

        // 确保有Animator组件
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found on player!");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isGameOver) return;

        // 检查是否碰撞到地面
        if (hit.gameObject.CompareTag("Ground"))
        {
            TriggerGameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGameOver) return;

        // 如果使用Rigidbody而不是CharacterController
        if (collision.gameObject.CompareTag("Ground"))
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        // 播放倒地动画
        if (playerAnimator != null)
        {
            playerAnimator.Play(fallAnimationName);
        }

        // 禁用玩家控制
        DisablePlayerControl();

        // 显示游戏结束UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // 可选：暂停游戏或结束游戏
        // Time.timeScale = 0f;

        Debug.Log("Game Over! Player fell to the ground.");
    }

    private void DisablePlayerControl()
    {
        // 禁用CharacterController
        if (characterController != null)
        {
            characterController.enabled = false;
        }


        // 禁用Rigidbody物理（如果有）
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}