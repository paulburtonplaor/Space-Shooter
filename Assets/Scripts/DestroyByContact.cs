using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	public GameObject playerExplosion;
	private GameController gameController;
	public int scoreValue;

	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		}

		if (gameController == null) {
			Debug.Log("Cannot find 'GameController' script.");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag.Equals("Boundary")) {
			return;
		}

		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag.Equals("Player")) {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		gameController.AddScore(scoreValue);

		Debug.Log(other.name);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
