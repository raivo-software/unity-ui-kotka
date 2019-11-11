using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InteractionPanelController : MonoBehaviour
{
    public ParticleSystem Particles;

    public Button ResetButton;
    public InputField SpeedField;
    public Toggle ParticlesActiveToggle;
    public Slider OpacitySlider;

    void Start()
    {
        ResetButton.onClick.AddListener(() => {
            Particles.Clear();
        });

        SpeedField.onValueChanged.AddListener((value) =>
        {
            try
            {
                float speed = float.Parse(value);
                Particles.startSpeed = speed;
            }
            catch(Exception e) { }
        });

        ParticlesActiveToggle.onValueChanged.AddListener((active) => {
            Particles.gameObject.SetActive(active);
        });

        Particles.startColor = new Color(1, 1, 1, OpacitySlider.value);
        OpacitySlider.onValueChanged.AddListener((value) =>
        {
            Particles.startColor = new Color(1, 1, 1, value);
        });
    }
}
