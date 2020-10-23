using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lira : MonoBehaviour
{
    public InputField inputField;

    private bool chatting = false;
    private bool inLightQuestion = false;
    private bool inPasswordQuestion = false;
    private bool lightOn = true;

    [SerializeField]
    LiraSpeaker[] speakers;

    [SerializeField]
    GameObject[] lights;

    private LiraSounds liraSounds;

    private void Awake()
    {
        liraSounds = FindObjectOfType<LiraSounds>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(chatting && Input.GetKeyDown(KeyCode.Return) && !inputField.text.Equals(""))
        {
            TalkToLira(inputField.text);
            inputField.text = "";
        }
    }

    public void TalkToLira(string message)
    {
        message = message.ToLower();

        if (inPasswordQuestion)
        {
            if (message.Contains("incorrect"))
            {
                PlayAudio("lira_access_granted");
                // grant access function
                inPasswordQuestion = false;
            }
            else
            {
                PlayAudio("lira_password_incorrect");
            }
        }
        else
        {
            if ((message.Contains("light") || message.Contains("lamp")) && message.Contains("off"))
            {
                PlayAudio("lira_light_off");
                SetLights(false);
            }
            else if ((message.Contains("light") || message.Contains("lamp")) && message.Contains("on"))
            {
                PlayAudio("lira_light_on");
                SetLights(true);
            }
            else if (message.Contains("watch") && message.Contains("video"))
            {
                PlayAudio("lira_watch_video");
                // enable tv function
            }
            else if (message.Contains("dark") || message.Contains("light") || message.Contains("lamp"))
            {
                if (lightOn)
                {
                    PlayAudio("lira_light_off_question");
                }
                else
                {
                    PlayAudio("lira_light_on_question");
                }

                inLightQuestion = true;
            }
            else if (inLightQuestion && message.Contains("yes"))
            {
                if (lightOn)
                {
                    PlayAudio("lira_light_off");
                    SetLights(false);
                }
                else
                {
                    PlayAudio("lira_light_on");
                    SetLights(true);
                }
            }
            else if (inLightQuestion && message.Contains("no"))
            {
                PlayAudio("lira_okay");
            }
            else if (message.Contains("who") && message.Contains("you"))
            {
                PlayAudio("lira_who");
            }
            else if (message.Contains("who") && message.Contains("organisation"))
            {
                PlayAudio("lira_who_organisation");
            }
            else if (message.Contains("who") && (message.Contains("i") || message.Contains("me")))
            {
                PlayAudio("lira_who_player");
            }
            else if (message.Contains("when") && message.Contains("ready"))
            {
                PlayAudio("lira_when_ready");
            }
            else if ((message.Contains("you're") || message.Contains("youre") || message.Contains("your")) && message.Contains("name"))
            {
                PlayAudio("lira_name");
            }
            else if (message.Contains("date") || message.Contains("year"))
            {
                PlayAudio("lira_date");
            }
            else if (message.Contains("my") && message.Contains("name"))
            {
                PlayAudio("lira_no_answer");
            }
            else
            {
                PlayAudio("lira_no_understand");
            }
        }
    }

    public void StartChatting()
    {
        chatting = true;
        inputField.gameObject.SetActive(true);
    }

    public void StopChatting()
    {
        chatting = false;
        inputField.text = "";
        inputField.gameObject.SetActive(false);
    }

    public void PlayAudio(string name)
    {
        Sound sound = liraSounds.FindSound(name);

        if(sound != null)
        {
            foreach (LiraSpeaker s in speakers)
            {
                s.liraSound.clip = sound.clip;
                s.liraSound.volume = sound.volume;
                s.liraSound.Play();
            }
        }
        else
        {
            Debug.LogWarning("No sound clip found for: " + name);
        }
    }

    public bool IsPaying()
    {
        return speakers[0].liraSound.isPlaying;
    }

    public void SetLights(bool state)
    {
        foreach(GameObject light in lights)
        {
            light.SetActive(state);
        }

        lightOn = state;
    }
}
