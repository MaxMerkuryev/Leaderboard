using UnityEngine;
using UnityEngine.UI;
using System;

public class InputFieldView : MonoBehaviour
{
	[SerializeField] private InputField _inputField;

	public Action OnValidate { get; set; }
	public bool IsValid { get; protected set; }

	public string Value
	{
		get => _inputField.text;
		set => _inputField.text = value;
	}

	private void OnEnable()
	{
		Clear();

		_inputField.onValueChanged.AddListener(ValidateInput);
	}

	private void OnDisable() => _inputField.onValueChanged.RemoveListener(ValidateInput);

	protected virtual void ValidateInput(string input)
	{
		IsValid = string.IsNullOrEmpty(input) == false;
		OnValidate?.Invoke();
	}

	private void Clear() => _inputField.text = string.Empty;
}