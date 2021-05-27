using UnityEngine;
using UnityEngine.SceneManagement;

namespace Biweekly
{
	[CreateAssetMenu(fileName = "SceneLoader", menuName = "Biweekly/Week 1/Scene Loader", order = 0)]
	public sealed class SceneLoader : ScriptableObject
	{
		public void ReloadScene()
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.buildIndex);
		}
	}
}