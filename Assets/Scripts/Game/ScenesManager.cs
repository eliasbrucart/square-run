using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager instanceScenesManager;
    static public ScenesManager Instance { get { return instanceScenesManager; } }

    private void Awake()
    {
        if (instanceScenesManager != null && instanceScenesManager != this)
            Destroy(this.gameObject);
        else
            instanceScenesManager = this;
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
