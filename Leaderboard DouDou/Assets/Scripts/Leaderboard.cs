using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
	[SerializeField] private RectTransform _viewContent;
	[SerializeField] private Player _playerPrefab;
	[SerializeField] private EditView _editView;

	private List<Player> _players = new List<Player>();
	private Player _selectedPlayer;

	public void AddPlayer(string name, string score)
	{
		var newPlayer = Instantiate(_playerPrefab, _viewContent);

		newPlayer.SetData(name, int.Parse(score));

		newPlayer.SelectAction += SetSelected;
		newPlayer.EditAction += OpenEditView;

		SetSelected(newPlayer);

		_players.Add(newPlayer);

		UpdateOrder();
	}
	
	private void OpenEditView(Player player)
	{
		gameObject.SetActive(false);

		RemovePlayer(player);

		_editView.gameObject.SetActive(true);
		_editView.SetPlayer(player);
	}

	public void EditPlayer(string currentName, string newName, string newScore)
	{
		var editedPlayer = _players.Find(x => x.Name == currentName);
		editedPlayer.SetData(newName, int.Parse(newScore));

		UpdateOrder();
	}

	public void RemovePlayer(Player player) 
	{
		player.SelectAction -= SetSelected;
		player.EditAction -= OpenEditView;

		_players.Remove(player);
		Destroy(player.gameObject);

		SetSelected(_players.Count > 0 ? _players[0] : null);

		UpdateOrder();
	}

	public void RemoveSelectedPlayer()
	{
		if (_selectedPlayer == null)
			return;

		RemovePlayer(_selectedPlayer);
	}

	private void SetSelected(Player player)
	{
		_selectedPlayer?.Deselect();
		_selectedPlayer = player;
		_selectedPlayer?.Select();
	}

	private void UpdateOrder()
	{
		_players = _players.OrderByDescending(x => x.Score).ToList();

		for (int i = 0; i < _players.Count; i++)
			_players[i].SetIndex(i);
	}

	public bool NameIsAvailable(string name) => _players.Exists(x => x.Name == name) == false;
}