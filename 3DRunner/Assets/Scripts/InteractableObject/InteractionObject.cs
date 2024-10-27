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
        // Toodo ItemObject가 아니면 다른 상호작용 오브젝트 컴포넌트를 할당
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
