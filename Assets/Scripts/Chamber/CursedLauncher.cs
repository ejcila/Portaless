using UnityEngine;
using System.Collections;

public class CursedLauncher : MonoBehaviour {
	public Transform pad;
	public Vector3 launchedRot = new Vector3(60, 0, 0);
	public float animationSpeed = 20f;
	public float timeToHide = 2f;
	public float flySpeed = 20f;

	[SerializeField] private bool _launched;
	[SerializeField] private bool _letHimFly;
	private Vector3 _velocity;

	[SerializeField] private GameObject _player;
	public Transform hitPoint;

	void Start() {
		_player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update() {
		if (_launched) {
			pad.localRotation = Quaternion.Slerp(pad.localRotation, Quaternion.Euler(launchedRot), animationSpeed * Time.deltaTime);
			_letHimFly = true;
			_player.GetComponent<CharacterController>().enabled = false;
		} else {
			pad.localRotation = Quaternion.Slerp(pad.localRotation, Quaternion.Euler(Vector3.zero), animationSpeed * Time.deltaTime);
		}

		if (_letHimFly) {
			_player.transform.position = Vector3.Lerp(_player.transform.position, hitPoint.position, flySpeed * Time.deltaTime);
		}
	}

	IEnumerator IEHide() {
		yield return new WaitForSeconds(timeToHide);
		_launched = false;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player"))
			_launched = true;
	}

	private void OnTriggerExit(Collider other) {
		if (other.CompareTag("Player"))
			StartCoroutine(IEHide());
	}
}
