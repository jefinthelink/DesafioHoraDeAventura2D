using UnityEngine;
using UnityEngine.EventSystems;

public class UISFX : MonoBehaviour, IPointerEnterHandler
{
[SerializeField] private string stayAudioName = "Click";
    public void OnPointerEnter(PointerEventData eventData)
    {
       AudioHelper.instance.PlayAudio(stayAudioName);
    }

}
