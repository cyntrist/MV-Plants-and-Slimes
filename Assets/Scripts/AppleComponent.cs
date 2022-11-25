using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleComponent : MonoBehaviour
{
    #region methods
    /// <summary>
    /// Informs Game Manager that the apple has been picked and destroys the gameobject
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (gameManager != null)
        {
            gameManager.OnPickApple();
            Destroy(this.gameObject);
        }
    }
    #endregion
}
