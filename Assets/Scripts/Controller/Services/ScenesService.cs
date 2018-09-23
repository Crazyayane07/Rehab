using UnityEngine.SceneManagement;

namespace Rehab.Services
{
    public interface IScenesService
    {
        void LoadScene(int id);
    }

    public class ScenesService : IScenesService
    {
        public void LoadScene(int id)
        {
            SceneManager.LoadScene(id);
        }
    }
}
