using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class DialogUIScript : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField] private TextMeshProUGUI txtDialog, txtSpeakerName;
#pragma warning restore 0649

    public DialogueRunner dialogRunner;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
