using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SceneGameManager : Singleton<SceneGameManager> {
	[Header("UI")]
	[SerializeField, SceneAsset] private string gameUI;
	[SerializeField, SceneAsset] private string menuUI;

	private Scene currentScene;

	protected override void Awake() {
		base.Awake();
		
		Assert.IsTrue(!string.IsNullOrEmpty(menuUI));
		Assert.IsTrue(!string.IsNullOrEmpty(gameUI));
	}

	private void Start() {
		currentScene = SceneManager.GetActiveScene();
	}

	private void LoadAddictive(int index) {
		SceneManager.LoadScene(index, LoadSceneMode.Additive);
	}
	
	private void LoadAddictive(string nameScene) {
		SceneManager.LoadScene(nameScene, LoadSceneMode.Additive);
	}
	
	public void LoadGameUI() {
		LoadAddictive(gameUI);
	}

	public void LoadMenuUI() {
		LoadAddictive(menuUI);
	}

	public void LoadGame() {
		SceneManager.LoadScene(1, LoadSceneMode.Single);
		LoadGameUI();
	}
	
	public void LoadMenu() {
		SceneManager.LoadScene(0, LoadSceneMode.Single);
		LoadMenuUI();
	}

	public void ReloadScene() {
		SceneManager.LoadScene(currentScene.buildIndex, LoadSceneMode.Single);
	}
}