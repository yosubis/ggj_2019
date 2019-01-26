using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
	[SerializeField] private float _maxEnergy;
	private float _currentEnergy;
	[SerializeField] private float _depletionPerSecond;
	[SerializeField] private float _rechargePerSecond;
	private bool _isCharging;

	[SerializeField] private Image _batteryGraphic;
	[SerializeField] private Color _lowPowerColor;
	[SerializeField] private Color _highPowerColor;
	private float _batteryGraphicWidth = 80;

	[SerializeField] private GameObject _failureScreen;

	void Awake(){
		_currentEnergy = _maxEnergy;
		_isCharging = true;
	}

	private float energyPct{
		get{
			return _currentEnergy/_maxEnergy;
		}
	}

	public bool hasEnergy{
		get{
			return _currentEnergy > 0;
		}
	}

	public void Fill(){
		//print("Energy: "+_currentEnergy+"/"+_maxEnergy);
		if(_currentEnergy < _maxEnergy){
			_currentEnergy += _rechargePerSecond * Time.deltaTime;
			_batteryGraphic.color = Color.Lerp(_lowPowerColor, _highPowerColor, energyPct);
			_batteryGraphic.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _batteryGraphicWidth * energyPct);
		}else{
			_currentEnergy = _maxEnergy;
		}
	}

	public void Deplete(){
		//print("Energy: "+_currentEnergy+"/"+_maxEnergy);
		if(_currentEnergy > 0){
			_currentEnergy -= _depletionPerSecond * Time.deltaTime;
			_batteryGraphic.color = Color.Lerp(_lowPowerColor, _highPowerColor, energyPct);
			_batteryGraphic.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _batteryGraphicWidth * energyPct);
		}else{
			//TODO get the MoveCharacter component, check if the target tile is not a docking station. If it is not, die
			//print("Death!!!!!!");
			_failureScreen.SetActive(true);
		}
	}

	void Update(){
		if(_isCharging){
			Fill();
		}else{
			Deplete();
		}
	}

	public void StartCharge(){
		_isCharging = true;
	}

	public void EndCharge(){
		_isCharging = false;
	}
}
