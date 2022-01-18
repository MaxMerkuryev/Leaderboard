using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private Text _number;
	[SerializeField] private Text _name;
	[SerializeField] private Text _score;
	[SerializeField] private GameObject _selection;
		
	public Action<Player> SelectAction;
	public Action<Player> EditAction;

	public string Name { get; private set; }
	public int Score { get; private set; }
	
	public void SetData(string name, int score)
	{
		Name = name;
		Score = score;

		_name.text = Name;
		_score.text = Score.ToString();
	}

	public void SetIndex(int index)
	{
		transform.SetSiblingIndex(index);
		_number.text = (index + 1).ToString();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
			SelectAction?.Invoke(this);
		else if (eventData.button == PointerEventData.InputButton.Right)
			Edit();
	}

	public void Select() => _selection.SetActive(true);
	public void Deselect() => _selection.SetActive(false);
	private void Edit() => EditAction?.Invoke(this);
}