using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControllerLoader : MonoBehaviour {

	void Awake () {
        SceneManager.LoadScene("GameControllers",LoadSceneMode.Additive);
	}
	

}
