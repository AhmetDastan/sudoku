
/*The MIT License (MIT)
Copyright(c) 2015, Eliot Lash
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraAnchor : MonoBehaviour
{
	public enum AnchorType
	{
		BottomLeft,
		BottomCenter,
		BottomRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		TopLeft,
		TopCenter,
		TopRight,
	};
	public AnchorType anchorType;
	public Vector3 anchorOffset;

	IEnumerator updateAnchorRoutine; //Coroutine handle so we don't start it if it's already running

	// Use this for initialization
	void Start()
	{
		updateAnchorRoutine = UpdateAnchorAsync();
		StartCoroutine(updateAnchorRoutine);
	}

	/// <summary>
	/// Coroutine to update the anchor only once ViewportHandler.Instance is not null.
	/// </summary>
	IEnumerator UpdateAnchorAsync()
	{
		uint cameraWaitCycles = 0;
		while (ViewportHandler.Instance == null)
		{
			++cameraWaitCycles;
			yield return new WaitForEndOfFrame();
		}
		if (cameraWaitCycles > 0)
		{
			print(string.Format("CameraAnchor found ViewportHandler instance after waiting {0} frame(s). You might want to check that ViewportHandler has an earlie execution order.", cameraWaitCycles));
		}
		UpdateAnchor();
		updateAnchorRoutine = null;
	}

	void UpdateAnchor()
	{
		switch (anchorType)
		{
			case AnchorType.BottomLeft:
				SetAnchor(ViewportHandler.Instance.BottomLeft);
				break;
			case AnchorType.BottomCenter:
				SetAnchor(ViewportHandler.Instance.BottomCenter);
				break;
			case AnchorType.BottomRight:
				SetAnchor(ViewportHandler.Instance.BottomRight);
				break;
			case AnchorType.MiddleLeft:
				SetAnchor(ViewportHandler.Instance.MiddleLeft);
				break;
			case AnchorType.MiddleCenter:
				SetAnchor(ViewportHandler.Instance.MiddleCenter);
				break;
			case AnchorType.MiddleRight:
				SetAnchor(ViewportHandler.Instance.MiddleRight);
				break;
			case AnchorType.TopLeft:
				SetAnchor(ViewportHandler.Instance.TopLeft);
				break;
			case AnchorType.TopCenter:
				SetAnchor(ViewportHandler.Instance.TopCenter);
				break;
			case AnchorType.TopRight:
				SetAnchor(ViewportHandler.Instance.TopRight);
				break;
		}
	}

	void SetAnchor(Vector3 anchor)
	{
		Vector3 newPos = anchor + anchorOffset;
		if (!transform.position.Equals(newPos))
		{
			transform.position = newPos;
		}
	}

#if UNITY_EDITOR
	// Update is called once per frame
	void Update()
	{
		if (updateAnchorRoutine == null)
		{
			updateAnchorRoutine = UpdateAnchorAsync();
			StartCoroutine(updateAnchorRoutine);
		}
		/*float ratioValue = 1;
		gameObject.transform.localScale = new Vector3(ratioValue, ratioValue, 1);*/
	}
#endif
}