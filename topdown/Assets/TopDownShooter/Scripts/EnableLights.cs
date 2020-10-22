/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using UnityEngine;

/*
 * Enable Lights when Player enters trigger
 * */
public class EnableLights : MonoBehaviour {
    
    [SerializeField] private CaptureOnTriggerEnter2D enableLightsTrigger;
    [SerializeField] private float targetLightIntensity;
    [SerializeField] private float lightIntensitySpeed;

    private float lightIntensity;

    private void Start() {
        if (enableLightsTrigger != null) {
            enableLightsTrigger.OnPlayerTriggerEnter2D += EnableLightsTrigger_OnPlayerTriggerEnter2D;
        }

        enabled = false;
    }

    private void EnableLightsTrigger_OnPlayerTriggerEnter2D(object sender, System.EventArgs e) {
        TurnLightsOn();
        enableLightsTrigger.OnPlayerTriggerEnter2D -= EnableLightsTrigger_OnPlayerTriggerEnter2D;
    }

    private void Update() {
        lightIntensity += lightIntensitySpeed * Time.deltaTime;
        lightIntensity = Mathf.Clamp(lightIntensity, 0f, targetLightIntensity);

        if (lightIntensity >= targetLightIntensity) {
            enabled = false;
        }
    }

    public void TurnLightsOn() {
        enabled = true;
    }

}
