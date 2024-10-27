using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    public void ShowInformation();
    public void Interact();
    public void CloseInformation();

}


public class InteractionObject : MonoBehaviour
{
    private IInteractable _interactable;
    private void Awake()
    {
        _interactable = GetComponent<ItemObject>();
        // Toodo ItemObject�� �ƴϸ� �ٸ� ��ȣ�ۿ� ������Ʈ ������Ʈ�� �Ҵ�
    }
    public void ShowInformation()
    {
        _interactable.ShowInformation();
    }
    public void Interact()
    {
        _interactable.Interact();
    }
    public void CloseInformation()
    {
        _interactable.CloseInformation();
    }
}
