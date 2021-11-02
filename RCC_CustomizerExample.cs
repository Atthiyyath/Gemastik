﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;


public class RCC_CustomizerExample : MonoBehaviour {

	#region singleton
	private static RCC_CustomizerExample instance;
	public static RCC_CustomizerExample Instance{	get{if(instance == null) instance = GameObject.FindObjectOfType<RCC_CustomizerExample>() as RCC_CustomizerExample; return instance;}}
	#endregion

	[Header("UI Menus")]
	public GameObject steeringAssistancesMenu;
	public GameObject colorsMenu;

	[Header("UI Sliders")]
	public Slider frontCamber;
	public Slider rearCamber;
	public Slider frontSuspensionDistances;
	public Slider rearSuspensionDistances;
	public Slider frontSuspensionDampers;
	public Slider rearSuspensionDampers;
	public Slider frontSuspensionSprings;
	public Slider rearSuspensionSprings;
	public Slider gearShiftingThreshold;
	public Slider clutchThreshold;

	[Header("UI Toggles")]
	public Toggle TCS;
	public Toggle ABS;
	public Toggle ESP;
	public Toggle SH;
	public Toggle counterSteering;
	public Toggle steeringSensitivity;
	public Toggle NOS;
	public Toggle turbo;
	public Toggle exhaustFlame;
	public Toggle revLimiter;
	public Toggle transmission;

	[Header("UI InputFields")]
	public InputField maxSpeed;
	public InputField maxBrake;
	public InputField maxTorque;

	[Header("UI Dropdown Menus")]
	public Dropdown drivetrainMode;

	void Start(){

		CheckUIs ();

	}

	public void CheckUIs (){

		if (!RCC_SceneManager.Instance.activePlayerVehicle)
			return;

		switch (RCC_SceneManager.Instance.activePlayerVehicle.wheelTypeChoise) {

		case RCC_CarControllerV3.WheelType.FWD:
			drivetrainMode.value = 0;
			break;

		case RCC_CarControllerV3.WheelType.RWD:
			drivetrainMode.value = 1;
			break;

		case RCC_CarControllerV3.WheelType.AWD:
			drivetrainMode.value = 2;
			break;

		case RCC_CarControllerV3.WheelType.BIASED:
			drivetrainMode.value = 3;
			break;

		}

	}

	public void OpenMenu(GameObject activeMenu){

		if (activeMenu.activeInHierarchy) {
			activeMenu.SetActive (false);
			return;
		}

		steeringAssistancesMenu.SetActive (false);
		colorsMenu.SetActive (false);

		activeMenu.SetActive (true);

	}

	public void CloseAllMenus(){

		steeringAssistancesMenu.SetActive (false);
		colorsMenu.SetActive (false);

	}

	public void SetCustomizationMode (bool state) {

		if (!RCC_SceneManager.Instance.activePlayerVehicle)
			return;

		RCC_Customization.SetCustomizationMode (RCC_SceneManager.Instance.activePlayerVehicle, state);

		if(state)
			CheckUIs ();

	}

	public void SetFrontCambersBySlider (Slider slider) {

		RCC_Customization.SetFrontCambers (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);
	
	}

	public void SetRearCambersBySlider (Slider slider) {

		RCC_Customization.SetRearCambers (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void TogglePreviewSmokeByToggle (Toggle toggle){

		RCC_Customization.SetSmokeParticle (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void TogglePreviewExhaustFlameByToggle (Toggle toggle){

		RCC_Customization.SetExhaustFlame (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}


	public void SetFrontSuspensionTargetsBySlider (Slider slider){

		RCC_Customization.SetFrontSuspensionsTargetPos (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void SetRearSuspensionTargetsBySlider (Slider slider){

		RCC_Customization.SetRearSuspensionsTargetPos (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void SetAllSuspensionTargetsByButton (float strength){

		RCC_Customization.SetAllSuspensionsTargetPos(RCC_SceneManager.Instance.activePlayerVehicle, strength);

	}

	public void SetFrontSuspensionDistancesBySlider (Slider slider){

		RCC_Customization.SetFrontSuspensionsDistances (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void SetRearSuspensionDistancesBySlider (Slider slider){

		RCC_Customization.SetRearSuspensionsDistances (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void SetGearShiftingThresholdBySlider (Slider slider){

		RCC_Customization.SetGearShiftingThreshold (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, .5f, .95f));

	}

	public void SetClutchThresholdBySlider (Slider slider){

		RCC_Customization.SetClutchThreshold (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, .1f, .9f));

	}

	public void SetDriveTrainModeByDropdown (Dropdown dropdown){

		switch (dropdown.value) {

		case 0:
			RCC_Customization.SetDrivetrainMode (RCC_SceneManager.Instance.activePlayerVehicle, RCC_CarControllerV3.WheelType.FWD);
			break;

		case 1:
			RCC_Customization.SetDrivetrainMode (RCC_SceneManager.Instance.activePlayerVehicle, RCC_CarControllerV3.WheelType.RWD);
			break;

		case 2:
			RCC_Customization.SetDrivetrainMode (RCC_SceneManager.Instance.activePlayerVehicle, RCC_CarControllerV3.WheelType.AWD);
			break;

		}

	}

	public void SetCounterSteeringByToggle (Toggle toggle){

		RCC_Customization.SetCounterSteering (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetNOSByToggle (Toggle toggle){

		RCC_Customization.SetNOS (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetTurboByToggle (Toggle toggle){

		RCC_Customization.SetTurbo (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetExhaustFlameByToggle (Toggle toggle){

		RCC_Customization.SetUseExhaustFlame (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetRevLimiterByToggle (Toggle toggle){

		RCC_Customization.SetRevLimiter (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetFrontSuspensionsSpringForceBySlider (Slider slider){

		RCC_Customization.SetFrontSuspensionsSpringForce (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, 10000f, 100000f));

	}

	public void SetRearSuspensionsSpringForceBySlider (Slider slider){

		RCC_Customization.SetRearSuspensionsSpringForce (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, 10000f, 100000f));

	}

	public void SetFrontSuspensionsSpringDamperBySlider (Slider slider){

		RCC_Customization.SetFrontSuspensionsSpringDamper (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, 1000f, 10000f));

	}

	public void SetRearSuspensionsSpringDamperBySlider (Slider slider){

		RCC_Customization.SetRearSuspensionsSpringDamper (RCC_SceneManager.Instance.activePlayerVehicle, Mathf.Clamp(slider.value, 1000f, 10000f));

	}

	public void SetMaximumSpeedByInputField (InputField inputField){

		RCC_Customization.SetMaximumSpeed (RCC_SceneManager.Instance.activePlayerVehicle, StringToFloat(inputField.text, 200f));
		inputField.text = RCC_SceneManager.Instance.activePlayerVehicle.maxspeed.ToString ();

	}

	public void SetMaximumTorqueByInputField (InputField inputField){

		RCC_Customization.SetMaximumTorque (RCC_SceneManager.Instance.activePlayerVehicle, StringToFloat(inputField.text, 2000f));
		inputField.text = RCC_SceneManager.Instance.activePlayerVehicle.maxEngineTorque.ToString ();

	}

	public void SetMaximumBrakeByInputField (InputField inputField){

		RCC_Customization.SetMaximumBrake (RCC_SceneManager.Instance.activePlayerVehicle, StringToFloat(inputField.text, 2000f));
		inputField.text = RCC_SceneManager.Instance.activePlayerVehicle.brakeTorque.ToString ();

	}

	public void RepairCar (){

		RCC_Customization.Repair (RCC_SceneManager.Instance.activePlayerVehicle);

	}

	public void SetESP(Toggle toggle){

		RCC_Customization.SetESP (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}
		
	public void SetABS(Toggle toggle){

		RCC_Customization.SetABS (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetTCS(Toggle toggle){

		RCC_Customization.SetTCS (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetSH(Toggle toggle){

		RCC_Customization.SetSH (RCC_SceneManager.Instance.activePlayerVehicle, toggle.isOn);

	}

	public void SetSHStrength(Slider slider){

		RCC_Customization.SetSHStrength (RCC_SceneManager.Instance.activePlayerVehicle, slider.value);

	}

	public void SetTransmission(Toggle toggle){

		RCC_Customization.SetTransmission (toggle.isOn);

	}

	public void SaveStats(){

		RCC_Customization.SaveStats (RCC_SceneManager.Instance.activePlayerVehicle);

	}

	public void LoadStats(){

		RCC_Customization.LoadStats (RCC_SceneManager.Instance.activePlayerVehicle);
		CheckUIs ();

	}

	public void ResetStats(){

		int selectedVehicleIndex = 0;

		if(GameObject.FindObjectOfType<RCC_Demo> ())
			selectedVehicleIndex = GameObject.FindObjectOfType<RCC_Demo> ().selectedVehicleIndex;

		

		CheckUIs ();

	}

	private float StringToFloat(string stringValue, float defaultValue){
		
		float result = defaultValue;
		float.TryParse(stringValue, out result);
		return result;

	}

}
