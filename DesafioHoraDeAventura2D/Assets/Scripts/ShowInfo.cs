using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
    [SerializeField] private ModesOfDhowInformation modes;
    [SerializeField] private CreateTutorial[] createTutorial;
    [SerializeField] private CreateHistory[] createHistories;
    [SerializeField] private TMP_Text tutorialName;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image art;
    [SerializeField] private GameObject content;
    [SerializeField] private float timeToChangeHistory = 3.0f, timeToChangeHistoryAux;
    private bool IsActive = false;

    private int index = 0;
private void Start() {
    SetValues();
}
    private void Update() {
        if(modes == ModesOfDhowInformation.history && IsActive)
        {
            timeToChangeHistoryAux -= Time.deltaTime;
            if(timeToChangeHistoryAux <= 0.0f)
            {
                timeToChangeHistoryAux = timeToChangeHistory;
                NextTutorial();
            }
        }
    }
private void ShowInformation(int index)
    {
        if(modes == ModesOfDhowInformation.tutorial)
        {
        tutorialName.text = createTutorial[index].tutorialName;
        description.text = createTutorial[index].description;
        art.sprite = createTutorial[index].art; 
        }
        else if(modes == ModesOfDhowInformation.history)
        {
        description.text = createHistories[index].description;
        art.sprite = createHistories[index].art; 
        }
    }

    private void SetValues()
    {
        timeToChangeHistoryAux = timeToChangeHistory;
    }
    public void NextTutorial()
    {
            index++;
            if(modes == ModesOfDhowInformation.tutorial)
            {
                if (index < createTutorial.Length)
                {
                    ShowInformation(index);
                }else
                {
                    HideTutorial();
                }
                
            }
            
            else if(modes == ModesOfDhowInformation.history)
            {
                if (index < createHistories.Length)
                {
                    ShowInformation(index);
                }
                else
                {
                    SceneManager.LoadScene("GamePlay1");
                }

            }
    }
    public void ShowTutorial()
    {
        content.SetActive(true);
        ShowInformation(index);
        IsActive = true;
    }
    public void HideTutorial()
    {
        index = 0;
        content.SetActive(false);
    IsActive = false;
    }

}

public enum ModesOfDhowInformation
{
tutorial,
history
}
