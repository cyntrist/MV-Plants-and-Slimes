using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("Bot�n pulsado.");
        GameManager.Instance.EnterState(GameManager.GameStates.GAME);
        GameManager.Instance.RequestStateChange(GameManager.GameStates.GAME);
    }
}
