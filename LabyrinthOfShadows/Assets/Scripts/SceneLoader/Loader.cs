using UnityEngine.SceneManagement;

namespace SceneLoader
{
    public class Loader
    {
        private static Scene targetScene;

        public enum Scene
        {
            MainMenuScene,
            GamePlayScene,
            SelectLevelScene,
            LevelCompletedScene,
            LevelFailedScene,
            LoadingScene
        }
    
        public void Load(Scene targetScene)
        {
            Loader.targetScene = targetScene;
            SceneManager.LoadScene(Scene.LoadingScene.ToString());
        }

        public void LoaderCallback()
        {
            SceneManager.LoadScene(targetScene.ToString());   
        }
    }
}
