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
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPickApple();
            Destroy(this.gameObject);
        }
    }
    #endregion
}
