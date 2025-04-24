using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class CharacterSwitcher : MonoBehaviour
{
    public List<GameObject> characters;
    private int currentCharacterIndex = 0;

    void Start()
    {
        ActivateCharacter(currentCharacterIndex);
    }

    public void OnSwitchCharacter(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            int direction = Mathf.RoundToInt(context.ReadValue<float>());

            Rigidbody rbCurrent = characters[currentCharacterIndex].GetComponent<Rigidbody>();
            characters[currentCharacterIndex].GetComponent<PlayerMovement>().enabled = false;
            rbCurrent.constraints = RigidbodyConstraints.FreezeAll;

            currentCharacterIndex = (currentCharacterIndex + direction + characters.Count) % characters.Count;

            ActivateCharacter(currentCharacterIndex);
        }
    }

    void ActivateCharacter(int index)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            Rigidbody rb = characters[i].GetComponent<Rigidbody>();

            if (i == index)
            {
                characters[i].GetComponent<PlayerMovement>().enabled = true;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            else
            {
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }
}