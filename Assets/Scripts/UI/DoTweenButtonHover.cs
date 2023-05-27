using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.UI.Button)), DisallowMultipleComponent]
public class DoTweenButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	[Header("Tween")] 
	[SerializeField] private float size = 15f; 
	[SerializeField, Range(0.1f, 0.5f)] private float duration = 0.25f;
	[SerializeField] private Ease ease = Ease.Linear;
	    
	private UnityEngine.UI.Button button = null;
	private RectTransform rectTransform = null;

	private Vector2 defaultSizeDelta = Vector2.zero;
	private Vector2 endValue = Vector2.zero;

	private void Awake() {
		button = GetComponent<UnityEngine.UI.Button>();
		rectTransform = transform as RectTransform;
	}

	private void Start() {
		defaultSizeDelta = rectTransform.sizeDelta;

		endValue = new Vector2(defaultSizeDelta.x + size, defaultSizeDelta.y + size);
	}

	private void OnDestroy() {
		rectTransform.DOKill();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		rectTransform.DOSizeDelta(endValue, duration).SetLoops(0).SetRecyclable(true).SetUpdate(UpdateType.Late).SetEase(ease);
	}

	public void OnPointerExit(PointerEventData eventData) {
		rectTransform.DOSizeDelta(defaultSizeDelta, duration).SetLoops(0).SetRecyclable(true).SetUpdate(UpdateType.Late).SetEase(ease);
	}
}