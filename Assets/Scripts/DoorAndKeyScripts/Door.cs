using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator _animator;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Open")]
    public void Open()
    {
        _animator.SetTrigger(name: "Open");
    }
}
