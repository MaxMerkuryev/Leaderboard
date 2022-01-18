using UnityEngine;

public class NameFieldView : InputFieldView
{
	[SerializeField] private Leaderboard _leaderboardView;

	protected override void ValidateInput(string input)
	{
		IsValid = string.IsNullOrEmpty(input) == false && _leaderboardView.NameIsAvailable(input);
		OnValidate?.Invoke();
	}
}