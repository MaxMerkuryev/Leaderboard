using UnityEngine;

public class AddView : MonoBehaviour
{
	[SerializeField] protected Leaderboard _leaderboardView;

	[Space(10)]

	[SerializeField] protected InputFieldView _nameView;
	[SerializeField] protected InputFieldView _scoreView;

	public void Submit() => _leaderboardView.AddPlayer(_nameView.Value, _scoreView.Value);
}