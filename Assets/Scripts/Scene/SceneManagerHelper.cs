using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneManagerHelper : MonoBehaviour
    {
        public IEnumerator LoadAsyncScene(string sceneName)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
            
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            asyncLoad.allowSceneActivation = true;
        }
    }
}
