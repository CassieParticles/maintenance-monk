using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

    bool isOpen = false;
    [SerializeField] GameObject SettingsObject;
    Slider MasterVolume;
    Slider SFXVolume;
    Slider MusicVolume;
    Slider DialogueVolume;


    private void Start() {
        MasterVolume = SettingsObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        SFXVolume = SettingsObject.transform.GetChild(0).GetChild(1).GetComponent<Slider>();
        MusicVolume = SettingsObject.transform.GetChild(0).GetChild(2).GetComponent<Slider>();
        DialogueVolume = SettingsObject.transform.GetChild(0).GetChild(3).GetComponent<Slider>();



        SettingsObject.SetActive(false);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OpenSettings()
    {
        isOpen = !isOpen;
        SettingsObject.SetActive(isOpen);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen) {
            // TODO for Rebecca:
            //
            //Set the master volume in wwise to be = MasterVolume.value, sfx volume to be SFXVolume.value, and so on. 
            Debug.Log("MasterVolume: " + MasterVolume.value * 100 + "% \t" + "SFXVolume: " + SFXVolume.value * 100 + "%\n" +
                      "MusicVolume: " + MusicVolume.value * 100 + "% \t" + "DialogueVolume: " + DialogueVolume.value * 100 + "%\n");
            //If you want to have more than just master volume I can add more sliders easily
            //You can also remove the debug when youre sure the audio scales with the slider
        }
    }
}
