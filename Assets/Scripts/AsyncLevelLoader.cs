using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLevelLoader : MonoBehaviour
{
    public async Task AsyncLoadLevel(string levelName)
    {
        var operation = SceneManager.LoadSceneAsync(levelName);

        while (!operation.isDone)
        {
            await Task.Yield();
        }
    }
}