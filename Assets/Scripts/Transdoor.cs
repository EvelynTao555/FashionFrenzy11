
using UnityEngine;
using System.Collections;

public class AdvancedDoorTeleporter : MonoBehaviour
{
    [Header("传送门设置")]
    public string targetDoorName = "Transdoor1";
    public string exitDoorName = "Transdoor2";
    public float teleportCooldown = 0.5f;  // 传送冷却时间
    public bool maintainRelativeVelocity = true; // 是否保持相对速度

    private CharacterController characterController;
    private GameObject exitDoor;
    private bool isTeleporting = false;
    private Vector3 storedVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        exitDoor = GameObject.Find(exitDoorName);

        if (exitDoor == null)
            Debug.LogError($"找不到出口传送门: {exitDoorName}");
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == targetDoorName && !isTeleporting)
        {
            StartCoroutine(TeleportSequence());
        }
    }

    IEnumerator TeleportSequence()
    {
        isTeleporting = true;

        // 保存当前速度（如果需要）
        if (maintainRelativeVelocity)
        {
            // 这里可以保存角色的移动状态
        }

        // 短暂延迟确保物理更新完成
        yield return new WaitForFixedUpdate();

        // 执行传送
        characterController.enabled = false;
        transform.position = exitDoor.transform.position;

        // 可选：调整旋转以匹配出口方向
        // transform.rotation = exitDoor.transform.rotation;

        characterController.enabled = true;

        Debug.Log($"传送完成: {targetDoorName} -> {exitDoorName}");

        // 冷却时间
        yield return new WaitForSeconds(teleportCooldown);
        isTeleporting = false;
    }
}