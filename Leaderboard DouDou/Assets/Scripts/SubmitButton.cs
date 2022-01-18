using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Button))]
public class SubmitButton : MonoBehaviour
{
	[SerializeField] private List<InputFieldView> _inputFields;

	private Button _button;
	private void Awake() => _button = GetComponent<Button>();

	private void OnEnable()
	{
		foreach (var field in _inputFields)
			field.OnValidate += SetButtonState;

		SetButtonState();
	}

	private void OnDisable()
	{
		foreach (var field in _inputFields)
			field.OnValidate -= SetButtonState;
	}

	private void SetButtonState()
		=> _button.interactable = _inputFields.Count(x => x.IsValid == false) == 0;
}