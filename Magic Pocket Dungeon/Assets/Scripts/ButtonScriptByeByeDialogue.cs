using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ButtonScriptByeByeDialogue : MonoBehaviour
{
    [SerializeField]
    GameObject _diag;

    public void DisableDialogue()
    {
        _diag.SetActive(false);
    }
}
