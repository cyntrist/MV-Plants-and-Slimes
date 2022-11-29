using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("Botón pulsado.");
        GameManager.Instance.RequestStateChange(GameManager.GameStates.GAME);
    }
}
