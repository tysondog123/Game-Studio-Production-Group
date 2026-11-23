using UnityEngine;
using UnityEngine.Events;

public class TriggerBox : MonoBehaviour
{
    [SerializeField]
    UnityEvent e_EnterTrigger = new UnityEvent();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e_EnterTrigger.Invoke();
            Destroy(gameObject);
        }
    }
}
