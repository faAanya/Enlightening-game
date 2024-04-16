using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    public Button discordButton;
    public Button soundCloudButton;

    public void Awake()
    {
        soundCloudButton.onClick.AddListener(() => { Application.OpenURL("https://soundcloud.com/mararatik"); });
        discordButton.onClick.AddListener(() => { Application.OpenURL("https://discord.gg/4HpfYUbs"); });

    }
}
