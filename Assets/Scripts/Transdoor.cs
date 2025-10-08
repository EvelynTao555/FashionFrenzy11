
using UnityEngine;
using System.Collections;

public class AdvancedDoorTeleporter : MonoBehaviour
{
    [Header("����������")]
    public string targetDoorName = "Transdoor1";
    public string exitDoorName = "Transdoor2";
    public float teleportCooldown = 0.5f;  // ������ȴʱ��
    public bool maintainRelativeVelocity = true; // �Ƿ񱣳�����ٶ�

    private CharacterController characterController;
    private GameObject exitDoor;
    private bool isTeleporting = false;
    private Vector3 storedVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        exitDoor = GameObject.Find(exitDoorName);

        if (exitDoor == null)
            Debug.LogError($"�Ҳ������ڴ�����: {exitDoorName}");
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

        // ���浱ǰ�ٶȣ������Ҫ��
        if (maintainRelativeVelocity)
        {
            // ������Ա����ɫ���ƶ�״̬
        }

        // �����ӳ�ȷ������������
        yield return new WaitForFixedUpdate();

        // ִ�д���
        characterController.enabled = false;
        transform.position = exitDoor.transform.position;

        // ��ѡ��������ת��ƥ����ڷ���
        // transform.rotation = exitDoor.transform.rotation;

        characterController.enabled = true;

        Debug.Log($"�������: {targetDoorName} -> {exitDoorName}");

        // ��ȴʱ��
        yield return new WaitForSeconds(teleportCooldown);
        isTeleporting = false;
    }
}