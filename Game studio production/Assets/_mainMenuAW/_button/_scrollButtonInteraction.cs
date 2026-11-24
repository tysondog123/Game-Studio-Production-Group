using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class _scrollButtonInteraction : MonoBehaviour,
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Animator scrollAnimator;

    private float currentProgress = 1f; // scroll movement current
    private float targetProgress = 1f; // scroll movement to be

    [SerializeField] private float duration = 0.5f; // speed of movement

    [SerializeField] private Button button;
    [SerializeField] private GameObject buttonText;

    private void Start()
    {
        button.interactable = false;
        buttonText.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetProgress = 0f;

        //scrollAnimator.SetFloat("ScrollProgress", 0f);

        Debug.Log("Mouse entered scroll button");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetProgress = 1f;

        //scrollAnimator.SetFloat("ScrollProgress", 1f);

        Debug.Log("Mouse exited scroll button");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!button.interactable) return;

        targetProgress = 1f;

        //scrollAnimator.SetFloat("ScrollProgress", 1f);

        Debug.Log("Mouse clicked scroll button");
    }

    private void Update()
    {
        currentProgress = Mathf.MoveTowards(
            currentProgress,
            targetProgress,
            Time.deltaTime / duration
        );

        scrollAnimator.SetFloat("ScrollProgress", currentProgress);

        bool isFullyOpen = targetProgress == 0f &&
                   Mathf.Approximately(currentProgress, 0f);

        buttonText.SetActive(isFullyOpen);
        button.interactable = isFullyOpen;
    }

}
