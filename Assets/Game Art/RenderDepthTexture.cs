using UnityEngine;
using System.Collections;

// Component to tell camera to make a depth pass, used for soft particles and such things as clouds.
public class RenderDepthTexture : MonoBehaviour 
{
	private Camera affectedCamera;
	
	void Awake () 
	{
		affectedCamera = gameObject.GetComponent<Camera>();
		affectedCamera.depthTextureMode = DepthTextureMode.Depth;
	}

	void OnEnable()
	{
		affectedCamera.depthTextureMode = DepthTextureMode.Depth;
	}

	void OnDisable()
	{
		affectedCamera.depthTextureMode = DepthTextureMode.None;
	}
}
