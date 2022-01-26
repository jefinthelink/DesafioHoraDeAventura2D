using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISFX : MonoBehaviour, IPointerEnterHandler
{

[SerializeField] private string stayAudioName = "Click";
[SerializeField] private string clickAudioName = "Click2";
private Button bt;

private void Start() {
    SetValues();
}

private void SetValues()
{
    bt = transform.GetComponent<Button>();
    bt.onClick.AddListener(ClickSFX);
}
    public void OnPointerEnter(PointerEventData eventData)
    {
       AudioHelper.instance.PlayAudio(stayAudioName);
    }

    void ClickSFX()
    {
        AudioHelper.instance.PlayAudio(clickAudioName);
    }

}
