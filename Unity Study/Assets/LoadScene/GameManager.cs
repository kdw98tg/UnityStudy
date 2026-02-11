using UnityEngine;

namespace LoadScene
{
    public class GameManager : MonoBehaviour
    {
        private SceneManager sceneManager;

        private void Awake()
        {
            sceneManager = GetComponentInChildren<SceneManager>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                sceneManager.LoadSceneAsync(SceneId.Scene2, 3f, _onLoadingAction: (progress) =>
                {
                    Debug.Log(progress);
                });
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                sceneManager.LoadSceneAsync(SceneId.Scene1);
            }
        }
    }
}