using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputSwitcher : MonoBehaviour
{
    [SerializeField] private LegacyInputHandler legacyInput;
    [SerializeField] private NewInputHandler newInput;
    [SerializeField] private TextMeshProUGUI statusText;

    [SerializeField] private PlayerController playerController;

    void Start()
    {
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }
        ActivateLegacyInput();
    }
    

    public void ActivateLegacyInput()
    {
        legacyInput.enabled = true;
        newInput.enabled = false;
        
        playerController.SetInputHandler(legacyInput);

        Debug.Log("Switched to: LEGACY INPUT MANAGER");
        if (statusText != null) statusText.text = "Active System: Legacy (Keys: Arrows, Space)";
    }

    public void ActivateNewInput()
    {
        legacyInput.enabled = false;
        newInput.enabled = true;

        playerController.SetInputHandler(newInput);

        Debug.Log("Switched to: NEW INPUT SYSTEM");
        if (statusText != null) statusText.text = "Active System: New (Keys: WASD, Space) | Press R to remap Jump";
    }
}