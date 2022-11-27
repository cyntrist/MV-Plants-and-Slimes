using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void OnButtonPress()
    {
        GameManager.Instance.EnterState(GameManager.GameStates.GAME);
        Debug.Log("Botón pulsado.");
    }
}
