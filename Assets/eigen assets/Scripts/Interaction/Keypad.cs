using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Keypad : FocusableInteractable, IUnlocker
{
    public string code = "0000";
    public int codeLength = 4;

    private string enteredCode = "";

    private AudioSource keypadSound;

    public AudioClip keypressSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    public event UnlockHandler Unlocked;

    private void Awake()
    {
        keypadSound = gameObject.AddComponent<AudioSource>();
        keypadSound.spatialBlend = 1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        if (focusController.focused)
        {
            if(Input.GetMouseButtonDown(0))
            {
                CheckHitObject();
            }
        }
    }

    public override void Exit()
    {
        base.Exit();

        enteredCode = "";
    }

    void CheckHitObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 10f);

        foreach (RaycastHit hit in hits)
        {
            if(hit.transform.CompareTag("KeypadButton"))
            {
                if (keypressSound != null)
                {
                    keypadSound.clip = keypressSound;
                    keypadSound.Play();
                }

                enteredCode += hit.transform.name;

                if (enteredCode.Length >= codeLength)
                {
                    if (code.Equals(enteredCode))
                    {
                        Unlocked?.Invoke();
                        Exit();
                        Debug.Log("Correct");

                        if (keypressSound != null)
                        {
                            keypadSound.clip = correctSound;
                            keypadSound.Play();
                        }
                    }
                    else
                    {
                        Debug.Log("Incorrect");

                        if (keypressSound != null)
                        {
                            keypadSound.clip = incorrectSound;
                            keypadSound.Play();
                        }
                    }

                    enteredCode = "";
                }
            }
        }
    }
}
