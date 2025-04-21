using UnityEngine;

public class RestartInputHandler : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Instance != null && !GameManager.Instance.enabled &&
         (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))){
            GameManager.Instance.enabled = true;
            GameManager.Instance.SendMessage("NewGame");
         }
    }
}
