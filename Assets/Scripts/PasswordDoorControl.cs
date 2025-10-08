using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PasswordDoorControl : MonoBehaviour
{
    [Header("interaction")]
    public float interactiveDistance = 5;
    private bool canInteractive = false;

    [Header("Password")]
    [SerializeField] private string correctPassword = "6741";

    [Header("UI")]
    [SerializeField] private GameObject passwordPanel;
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private TextMeshProUGUI messageText;

    private bool unlockDoor = true;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (passwordPanel != null)
            passwordPanel.SetActive(false);

        if (messageText != null)
            messageText.text = "";
    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(Camera.main.transform.position, this.transform.position) < interactiveDistance)
        {
            Interactive.overObject = true;
            canInteractive = true;
        }
    }

    private void OnMouseDown()
    {
        if (canInteractive)
        {
            OpenPasswordPanel();
        }
    }

    private void OnMouseExit()
    {
        canInteractive = false;
        Interactive.overObject = false;
    }

    private void Update()
    {
        
        if (passwordPanel != null && passwordPanel.activeSelf)
        {
           
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                CheckPassword();
            }

            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePasswordPanel();
            }
        }
    }

    public void OpenPasswordPanel()
    {
        if (passwordPanel != null)
        {
            passwordPanel.SetActive(true);

            if (passwordInput != null)
                passwordInput.text = "";

            if (messageText != null)
                messageText.text = "";

            if (passwordInput != null)
                passwordInput.Select();
        }
    }

    public void ClosePasswordPanel()
    {
        if (passwordPanel != null)
            passwordPanel.SetActive(false);
    }

    public void CheckPassword()
    {
        if (passwordInput == null) return;

        string inputPassword = passwordInput.text;

        if (inputPassword.Length != 4)
        {
            ShowMessage("Must be 4 digits!", Color.red);
            return;
        }

        if (inputPassword == correctPassword)
        {
            ShowMessage("Correct", Color.green);
            StartCoroutine(ExecuteTaskAfterDelay(1.0f));
        }
        else
        {
            ShowMessage("Wrong password, please try again", Color.red);
        }
    }

    private void ShowMessage(string message, Color color)
    {
        if (messageText != null)
        {
            messageText.text = message;
            messageText.color = color;
        }
    }

    private IEnumerator ExecuteTaskAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        ExecuteTask();

        ClosePasswordPanel();
    }

    private void ExecuteTask()
    {
        if (unlockDoor)
        {
            Debug.Log("DoorUnlocked");
            animator.SetBool("open", true);
        }
    }
}
