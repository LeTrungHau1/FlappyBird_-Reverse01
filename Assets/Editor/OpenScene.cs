using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class OpenScene : EditorWindow
{
    private static string _scenePath = "Assets/Scenes/{0}.unity";

    
    [MenuItem("OpenScene/Menu", false, 1)]
    public static void GameScene()
    {

        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());

        EditorSceneManager.OpenScene
           (string.Format(_scenePath, "SceneMenu"), OpenSceneMode.Single);
    }
   [MenuItem("OpenScene/PlayGame", false, 2)]
    public static void Demo()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());

        EditorSceneManager.OpenScene
           (string.Format(_scenePath, "SceneGame"), OpenSceneMode.Single);
    }

}
