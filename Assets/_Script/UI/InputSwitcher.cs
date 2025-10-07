using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class InputSwitcher : MonoBehaviour
{
    [SerializeField] private LegacyInputHandler legacyInput;
    [SerializeField] private NewInputHandler newInput;
    [SerializeField] private TextMeshProUGUI statusText; 

    void Start()
    {
        ActivateLegacyInput();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateLegacyInput();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateNewInput();
        }
    }

    public void ActivateLegacyInput()
    {
        legacyInput.enabled = true;
        newInput.enabled = false;
        Debug.Log("Switched to: LEGACY INPUT MANAGER");
        if (statusText != null) statusText.text = "Active System: Legacy (Keys: Arrows, Space)";
    }

    public void ActivateNewInput()
    {
        legacyInput.enabled = false;
        newInput.enabled = true;
        Debug.Log("Switched to: NEW INPUT SYSTEM");
        if (statusText != null) statusText.text = "Active System: New (Keys: WASD, Space) | Press R to remap Jump";
    }
}