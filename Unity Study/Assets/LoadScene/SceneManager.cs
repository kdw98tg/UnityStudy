using System;
using System.Collections;
using UnityEngine;

namespace LoadScene
{
    public class SceneManager : MonoBehaviour
    {
        public void LoadScene(SceneId _sceneId)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneId.ToString());
        }

        /// <summary>
        /// 지연시간 없이 비동기 작업 완료시, 바로 씬 전환
        /// </summary>
        /// <param name="_sceneId"></param>
        /// <param name="_onLoadingAction"></param>
        public void LoadSceneAsync(SceneId _sceneId, Action<float> _onLoadingAction = null)
        {
            StartCoroutine(LoadingAsync(_sceneId.ToString(), _onLoadingAction));
        }

        /// <summary>
        /// 로딩이 다 되어도 지연시간 후에 씬 전환
        /// </summary>
        /// <param name="_sceneId"></param>
        /// <param name="_loadingTime"></param>
        /// <param name="_onLoadingAction"></param>
        public void LoadSceneAsync(SceneId _sceneId, float _loadingTime, Action<float> _onLoadingAction = null)
        {
            StartCoroutine(LoadingAsync(_sceneId.ToString(), _loadingTime, _onLoadingAction));
        }


        // 지연시간 없이 그냥 로딩 되면 바로 씬 전환
        private IEnumerator LoadingAsync(string _name, Action<float> _onLoadingAction = null)
        {
            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_name);

            //로딩이 완료되는대로 씬을 활성화할것인지
            asyncOperation.allowSceneActivation = false;

            //로딩할 때 할 행동이 있으면 함
            _onLoadingAction?.Invoke(asyncOperation.progress);

            //씬 활성화
            asyncOperation.allowSceneActivation = true;

            yield return null;
        }

        // 지연시간 기다렸다가 씬 전환함
        // 지연시간은 디폴트 3초
        private IEnumerator LoadingAsync(string _name, float _shouldWaitTime, Action<float> _onLoadingAction = null)
        {
            AsyncOperation asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_name);

            //로딩이 완료되는대로 씬을 활성화할것인지
            asyncOperation.allowSceneActivation = false;

            float waitTime = 0f;

            //로딩이 완료되지 않았을 때
            while (!asyncOperation.isDone)
            {
                Debug.Log(asyncOperation.progress);

                waitTime += Time.deltaTime;

                //로딩할 때 할 행동이 있으면 함
                _onLoadingAction?.Invoke(asyncOperation.progress);

                //시간 다 채울때까지 기다림
                if (waitTime > _shouldWaitTime)
                {
                    //씬 활성화
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }

    public enum SceneId
    {
        Scene1,
        Scene2,
    }
}