using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class Menu : MonoBehaviour {
	[SerializeField] private Canvas canvas;
	[SerializeField] private Button btnNewGame;
	[SerializeField] private Button btnCredits;
	[SerializeField] private Button btnQuit;

	private void Awake() {
		canvas = GetComponent<Canvas>();
	}

	private void Start() {
		Assert.IsNotNull(btnNewGame, $"[UI] {nameof(btnNewGame)} is null reference!");
		Assert.IsNotNull(btnCredits, $"[UI] {nameof(btnCredits)} is null reference!");
		Assert.IsNotNull(btnQuit, $"[UI] {nameof(btnQuit)} is null reference!");
		
		btnNewGame.onClick.AddListener(LoadNewGame);
		//btnCredits.onClick
		btnQuit.onClick.AddListener(Application.Quit);
	}

	private void OnDestroy() {
		btnNewGame.onClick.RemoveAllListeners();
		btnCredits.onClick.RemoveAllListeners();
		btnQuit.onClick.RemoveAllListeners();
	}

	private void LoadNewGame() {
		SceneGameManager.Instance.LoadGame();
	}
}
