using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : UI
{
	[Header("Information")]
	[SerializeField] protected TMP_Text _title;
	[SerializeField] protected TMP_Text _description;

	[Header("Button Binding")]
	[SerializeField] protected Button _acceptButton;
	[SerializeField] protected Button _cancleButton;
	[SerializeField] protected Button _background;

	public event Action OnAcceptEvent;
	public event Action OnCancleEvent;

	public virtual void Init(string title, string description)
	{
		_description.text = description;
		Init(title);
	}
	public virtual void Init(string text)
	{
		_title.text = text;
		Init();
	}
	public override void Init()
	{
		OnAcceptEvent += Close;
		OnCancleEvent += Close;
		if(_background != null)
		{
			_background.onClick.AddListener(OnCancle);
		}
		if(_cancleButton != null)
		{
			_cancleButton.onClick.AddListener(OnCancle);
		}
		if (_acceptButton != null)
		{
			_acceptButton.onClick.AddListener(OnAccept);
		}
	}

	public virtual void OnCancle()
	{
		OnCancleEvent?.Invoke();
	}

	public override void Close()
	{
		this.gameObject.SetActive(false);
	}
	public virtual void OnAccept()
	{
		OnAcceptEvent?.Invoke();
	}

}