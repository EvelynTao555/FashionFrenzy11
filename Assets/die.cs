using UnityEngine;

public class PlayerDeathOnCollision : MonoBehaviour
{
    [Header("Animation Settings")]
    public Animator playerAnimator;
    public string dieBoolName = "Die";

    [Header("Collision Settings")]
    public string targetObjectName = "object1"; // ����ʹ�� Tag

    private void Start()
    {
        // �Զ���ȡ Animator ���
        if (playerAnimator == null)
        {
            playerAnimator = GetComponent<Animator>();
        }

        // ��� Animator �Ƿ����
        if (playerAnimator == null)
        {
            Debug.LogError("Animator component not found! Please assign it in the inspector.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ͨ�����Ƽ����ײ
        if (collision.gameObject.name == targetObjectName)
        {
            SetDieAnimation(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���ʹ�� Trigger ��ײ
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