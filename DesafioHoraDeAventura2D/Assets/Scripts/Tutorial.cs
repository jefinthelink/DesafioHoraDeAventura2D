using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CreateTutorial[] create;
    [SerializeField] private TMP_Text tutorialName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image art;
    [SerializeField] private GameObject content;
    [SerializeField] GameObject logo;

    private int index = 0;
    private void ShowInformation(int index)
    {
        tutorialName.text = create[index].tutorialName;
        description.text = create[index].description;
        art.sprite = create[index].art; 
    }
    public void NextTutorial()
    {
            index++;
        if (index < create.Length)
        {
            ShowInformation(index);
        }
        else
        {
            HideTutorial();
        }
    }
    public void ShowTutorial()
    {
        content.SetActive(true);
        ShowInformation(index);
    }
    public void HideTutorial()
    {
        index = 0;
        content.SetActive(false);
        logo.SetActive(true);
    }

}
