using UnityEngine;

public class EditView : AddView
{
	private string _oldName;
	private string _oldScore;

	public void SetPlayer(Player player)
	{
		_nameView.Value = _oldName = player.Name;
		_scoreView.Value = _oldScore = player.Score.ToString();
	}

	public void Cancel() => _leaderboardView.AddPlayer(_oldName, _oldScore);
}