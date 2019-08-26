using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMainMenuActions : MonoBehaviour
{
    [Header("Data Variables")]
    public FloatReference MusicVolume;
    public FloatReference SoundVolume;
    public GameEvent MusicRefreshed;
    public GameEvent SoundRefreshed;

    [Header("Panel Variables")]
    public Slider soundSlider;
    public Slider musicSlider;

    public void Start()
    {
        soundSlider.onValueChanged.AddListener(delegate { SoundChanged(); });
        soundSlider.value = SoundVolume.Value;
        musicSlider.onValueChanged.AddListener(delegate { MusicChanged(); });
        musicSlider.value = MusicVolume.Value;
    }

    public void SoundChanged()
    {
        SoundVolume.Value = soundSlider.value;
        SoundRefreshed.Raise();
    }

    public void MusicChanged()
    {
        MusicVolume.Value = musicSlider.value;
        MusicRefreshed.Raise();
    }
}
