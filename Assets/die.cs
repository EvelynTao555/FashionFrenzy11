using UnityEngine;

public class PlayerDeathOnCollision : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator playerAnimator;
    public string dieBoolName = "Die";

    [Header("Collision Settings")]
    public string targetObjectName = "object1"; // 或者使用 Tag

    private void Start()
    {
        // 自动获取 Animator 组件
        if (playerAnimator == null)
        {
            playerAnimator = GetComponent<Animator>();
        }

        // 检查 Animator 是否存在
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found! Please assign it in the inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 通过名称检测碰撞
        if (collision.gameObject.name == targetObjectName)
        {
            SetDieAnimation(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 如果使用 Trigger 碰撞
        if (other.gameObject.name == targetObjectName)
        {
            SetDieAnimation(true);
        }
    }

    private void SetDieAnimation(bool isDead)
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool(dieBoolName, isDead);
            Debug.Log("Die animation triggered: " + isDead);
        }
    }
}