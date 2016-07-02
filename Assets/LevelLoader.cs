using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	void Awake () {
        print("hello?");
        print(SceneManager.GetAllScenes().Length);
	    for(int i = 2; i < SceneManager.sceneCount; i++) {
            SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
            print(i);
        }
	}

}
