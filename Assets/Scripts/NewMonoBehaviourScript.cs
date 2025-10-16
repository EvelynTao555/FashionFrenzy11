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
        // ��ȡ�������
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();

        // ȷ����Animator���
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found on player!");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isGameOver) return;

        // ����Ƿ���ײ������
        if (hit.gameObject.CompareTag("Ground"))
        {
            TriggerGameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGameOver) return;

        // ���ʹ��Rigidbody������CharacterController
        if (collision.gameObject.CompareTag("Ground"))
        {
            TriggerGameOver();
        }
    }

    private void TriggerGameOver()
    {
        isGameOver = true;

        // ���ŵ��ض���
        if (playerAnimator != null)
        {
            playerAnimator.Play(fallAnimationName);
        }

        // ������ҿ���
        DisablePlayerControl();

        // ��ʾ��Ϸ����UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // ��ѡ����ͣ��Ϸ�������Ϸ
        // Time.timeScale = 0f;

        Debug.Log("Game Over! Player fell to the ground.");
    }

    private void DisablePlayerControl()
    {
        // ����CharacterController
        if (characterController != null)
        {
            characterController.enabled = false;
        }


        // ����Rigidbody��������У�
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
}