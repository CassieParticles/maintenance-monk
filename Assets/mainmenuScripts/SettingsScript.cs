using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{

    bool isOpen = false;
    [SerializeField] GameObject SettingsObject;
    [SerializeField] Slider VolumeSlider;


    private void Start() {
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
            //Set the volume in wwise to be = VolumeSlider.value
            Debug.Log("Volume: " + VolumeSlider.value * 100 + "%");
            //If you want to have more than just master volume I can add more sliders easily
            //You can also remove the debug when youre sure the audio scales with the slider
        }
    }
}
