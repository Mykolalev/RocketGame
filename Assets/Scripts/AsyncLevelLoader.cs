using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLevelLoader : MonoBehaviour
{
    public async Task AsyncLoadLevel(string levelName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            float operationProgresValue = operation.progress;
            await Task.Yield();
        }
    }
}