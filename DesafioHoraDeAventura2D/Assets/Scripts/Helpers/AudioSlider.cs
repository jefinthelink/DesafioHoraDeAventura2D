using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSlider : MonoBehaviour
{
    private GameObject option;
    public AudioMixer audioMixer;
    public Slider music;
    public Slider general;
    public Slider sfx;
    /// <summary> Valor padrão usado nos sliders para quando não houver um valor salvo </summary>
    float defaultVolumeValue = 0.5f;
    void Awake()
    {
        general.value = PlayerPrefs.GetFloat("VolumeMaster") == 0 ? defaultVolumeValue : PlayerPrefs.GetFloat("VolumeMaster");
        music.value = PlayerPrefs.GetFloat("VolumeMusica") == 0 ? defaultVolumeValue : PlayerPrefs.GetFloat("VolumeMusica");
        sfx.value = PlayerPrefs.GetFloat("VolumeSFX") == 0 ? defaultVolumeValue : PlayerPrefs.GetFloat("VolumeSFX");
    }

    void Start()
    {
        SetAudioMixer();
    }

    public void SetMusic()
    {
        float normalizedValue = NormalizedSliderValue(music.value);
        audioMixer.SetFloat("Music", normalizedValue);
        PlayerPrefs.SetFloat("VolumeMusica", music.value);
    }

    public void SetSfx()
    {
        float normalizedValue = NormalizedSliderValue(sfx.value);
        audioMixer.SetFloat("Sfx", normalizedValue);
        PlayerPrefs.SetFloat("VolumeSFX", sfx.value);
    }

    public void SetMaster()
    {
        float normalizedValue = NormalizedSliderValue(general.value);
        audioMixer.SetFloat("Master", normalizedValue);
        PlayerPrefs.SetFloat("VolumeMaster", general.value);
    }

    float NormalizedSliderValue(float sliderValue)
    {
        return Mathf.Log10(sliderValue) * 20;
    }

    /// <summary> Setta os valores para o audio mixer </summary>
    void SetAudioMixer()
    {
        float volumeMaster = NormalizedSliderValue(PlayerPrefs.GetFloat("VolumeMaster"));
        float volumeSfx = NormalizedSliderValue(PlayerPrefs.GetFloat("VolumeSFX"));
        float volumeMusica = NormalizedSliderValue(PlayerPrefs.GetFloat("VolumeMusica"));


        audioMixer.SetFloat("Master", volumeMaster);
        audioMixer.SetFloat("Sfx", volumeSfx);
        audioMixer.SetFloat("Music", volumeMusica);
    }

    public void seekSliders()
    {



        general = GameObject.Find("SliderMaster").GetComponent<Slider>();
        sfx = GameObject.Find("SliderSFX").GetComponent<Slider>();
        music = GameObject.Find("SliderMusic").GetComponent<Slider>();
        //general.onValueChanged.RemoveAllListeners();
        general.onValueChanged.AddListener(delegate { SetMaster(); });
        //sfx.onValueChanged.RemoveAllListeners();
        sfx.onValueChanged.AddListener(delegate { SetSfx(); });
        music.onValueChanged.AddListener(delegate { SetMusic(); });



    }
}
