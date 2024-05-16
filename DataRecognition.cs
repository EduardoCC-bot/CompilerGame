/*using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ControllerDataSender : MonoBehaviour
{
    private InputDevice leftController;
    private InputDevice rightController;

    private InputFeatureUsage<bool> gripButtonUsage;
    private InputFeatureUsage<bool> triggerButtonUsage;

    private InputFeatureUsage<bool> aButtonUsage;
    private InputFeatureUsage<bool> bButtonUsage;
    private InputFeatureUsage<bool> xButtonUsage;
    private InputFeatureUsage<bool> yButtonUsage;
    private InputFeatureUsage<bool> menuButtonUsage;
    private InputFeatureUsage<bool> oculusButtonUsage;

    private string filePath; // Ruta del archivo de texto

    private void Start()
    {
        InputDeviceCharacteristics controllerCharacteristics =
            InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.TrackedDevice;
        
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, leftHandDevices);
        leftController = leftHandDevices.FirstOrDefault();
        
        var rightHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, rightHandDevices);
        rightController = rightHandDevices.FirstOrDefault();

        gripButtonUsage = CommonUsages.gripButton;
        triggerButtonUsage = CommonUsages.triggerButton;

        // Definir usos para los botones A, B, X, Y, menú y Oculus
        aButtonUsage = new InputFeatureUsage<bool>("Button1");
        bButtonUsage = new InputFeatureUsage<bool>("Button2");
        xButtonUsage = new InputFeatureUsage<bool>("Button3");
        yButtonUsage = new InputFeatureUsage<bool>("Button4");
        menuButtonUsage = CommonUsages.menuButton;
        oculusButtonUsage = CommonUsages.primaryButton;

        // Definir la ruta del archivo de texto
        filePath = @"C:\Users\ecarr\Desktop\controller_data.txt";
    }

    private void Update()
    {
        bool leftGripButtonPressed;
        bool leftTriggerButtonPressed;
        bool rightGripButtonPressed;
        bool rightTriggerButtonPressed;

        bool aButtonPressed;
        bool bButtonPressed;
        bool xButtonPressed;
        bool yButtonPressed;
        bool menuButtonPressed;
        bool oculusButtonPressed;

        Vector3 leftHandPosition;
        Vector3 rightHandPosition;

        leftController.TryGetFeatureValue(gripButtonUsage, out leftGripButtonPressed);
        leftController.TryGetFeatureValue(triggerButtonUsage, out leftTriggerButtonPressed);
        rightController.TryGetFeatureValue(gripButtonUsage, out rightGripButtonPressed);
        rightController.TryGetFeatureValue(triggerButtonUsage, out rightTriggerButtonPressed);

        leftController.TryGetFeatureValue(aButtonUsage, out aButtonPressed);
        leftController.TryGetFeatureValue(bButtonUsage, out bButtonPressed);
        leftController.TryGetFeatureValue(xButtonUsage, out xButtonPressed);
        leftController.TryGetFeatureValue(yButtonUsage, out yButtonPressed);
        leftController.TryGetFeatureValue(menuButtonUsage, out menuButtonPressed);
        leftController.TryGetFeatureValue(oculusButtonUsage, out oculusButtonPressed);

        rightController.TryGetFeatureValue(aButtonUsage, out aButtonPressed);
        rightController.TryGetFeatureValue(bButtonUsage, out bButtonPressed);
        rightController.TryGetFeatureValue(xButtonUsage, out xButtonPressed);
        rightController.TryGetFeatureValue(yButtonUsage, out yButtonPressed);
        rightController.TryGetFeatureValue(menuButtonUsage, out menuButtonPressed);
        rightController.TryGetFeatureValue(oculusButtonUsage, out oculusButtonPressed);

        leftController.TryGetFeatureValue(CommonUsages.devicePosition, out leftHandPosition);
        rightController.TryGetFeatureValue(CommonUsages.devicePosition, out rightHandPosition);

        Debug.Log("Left Grip Button Pressed: " + leftGripButtonPressed);
        Debug.Log("Left Trigger Button Pressed: " + leftTriggerButtonPressed);
        Debug.Log("Right Grip Button Pressed: " + rightGripButtonPressed);
        Debug.Log("Right Trigger Button Pressed: " + rightTriggerButtonPressed);
*/
        //    if(aButtonPressed || bButtonPressed || xButtonPressed || yButtonPressed){
       //     Debug.Log("********************//////////////////////////////// ALGUN BOTÓN FUE DETECTADO ////////////////////////////////********************");
       /*
        }
        Debug.Log("A Button Pressed (Left): " + aButtonPressed);
        Debug.Log("B Button Pressed (Left): " + bButtonPressed);
        Debug.Log("X Button Pressed (Left): " + xButtonPressed);
        Debug.Log("Y Button Pressed (Left): " + yButtonPressed);
        Debug.Log("Menu Button Pressed (Left): " + menuButtonPressed);
        Debug.Log("Oculus Button Pressed (Left): " + oculusButtonPressed);

        Debug.Log("A Button Pressed (Right): " + aButtonPressed);
        Debug.Log("B Button Pressed (Right): " + bButtonPressed);
        Debug.Log("X Button Pressed (Right): " + xButtonPressed);
        Debug.Log("Y Button Pressed (Right): " + yButtonPressed);
        Debug.Log("Menu Button Pressed (Right): " + menuButtonPressed);
        Debug.Log("Oculus Button Pressed (Right): " + oculusButtonPressed);

        Debug.Log("Left Hand Position: " + leftHandPosition);
        Debug.Log("Right Hand Position: " + rightHandPosition);  
        
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine("Left Grip Button Pressed: " + leftGripButtonPressed);
            writer.WriteLine("Left Trigger Button Pressed: " + leftTriggerButtonPressed);
            writer.WriteLine("Right Grip Button Pressed: " + rightGripButtonPressed);
            writer.WriteLine("Right Trigger Button Pressed: " + rightTriggerButtonPressed);

            writer.WriteLine("A Button Pressed (Left): " + aButtonPressed);
            writer.WriteLine("B Button Pressed (Left): " + bButtonPressed);
            writer.WriteLine("X Button Pressed (Left): " + xButtonPressed);
            writer.WriteLine("Y Button Pressed (Left): " + yButtonPressed);
            writer.WriteLine("Menu Button Pressed (Left): " + menuButtonPressed);
            writer.WriteLine("Oculus Button Pressed (Left): " + oculusButtonPressed);

            writer.WriteLine("A Button Pressed (Right): " + aButtonPressed);
            writer.WriteLine("B Button Pressed (Right): " + bButtonPressed);
            writer.WriteLine("X Button Pressed (Right): " + xButtonPressed);
            writer.WriteLine("Y Button Pressed (Right): " + yButtonPressed);
            writer.WriteLine("Menu Button Pressed (Right): " + menuButtonPressed);
            writer.WriteLine("Oculus Button Pressed (Right): " + oculusButtonPressed);

            writer.WriteLine("Left Hand Position: " + leftHandPosition);
            writer.WriteLine("Right Hand Position: " + rightHandPosition);
        }

    }
}       
       
*/ 

       
       