using UnityEngine;

public class AspectUtility : MonoBehaviour {
	
//	public float _wantedaspectratio = 1.3333333f;
//	static float wantedaspectratio;
//	static camera cam;
//	static camera backgroundcam;
	
//	void awake () {
//		cam = getcomponent<camera>();
//		if (!cam) {
//			cam = camera.main;
//		}
//		if (!cam) {
//			debug.logerror ("no camera available");
//			return;
//		}
//		wantedaspectratio = _wantedaspectratio;
//		setcamera();
//	}
	
//	public static void setcamera () {
//		float currentaspectratio = (float)screen.width / screen.height;
//		// if the current aspect ratio is already approximately equal to the desired aspect ratio,
//		// use a full-screen rect (in case it was set to something else previously)
//		if ((int)(currentaspectratio * 100) / 100.0f == (int)(wantedaspectratio * 100) / 100.0f) {
//			cam.rect = new rect(0.0f, 0.0f, 1.0f, 1.0f);
//			if (backgroundcam) {
//				destroy(backgroundcam.gameobject);
//			}
//			return;
//		}
//		// pillarbox
//		if (currentaspectratio > wantedaspectratio) {
//			float inset = 1.0f - wantedaspectratio/currentaspectratio;
//			cam.rect = new rect(inset/2, 0.0f, 1.0f-inset, 1.0f);
//		}
//		// letterbox
//		else {
//			float inset = 1.0f - currentaspectratio/wantedaspectratio;
//			cam.rect = new rect(0.0f, inset/2, 1.0f, 1.0f-inset);
//		}
//		if (!backgroundcam) {
//			// make a new camera behind the normal camera which displays black; otherwise the unused space is undefined
//			backgroundcam = new gameobject("backgroundcam", typeof(camera)).getcomponent<camera>();
//			backgroundcam.depth = int.minvalue;
//			backgroundcam.clearflags = cameraclearflags.solidcolor;
//			backgroundcam.backgroundcolor = color.black;
//			backgroundcam.cullingmask = 0;
//		}
//	}
	
//	public static int screenheight {
//		get {
//			return (int)(screen.height * cam.rect.height);
//		}
//	}
	
//	public static int screenwidth {
//		get {
//			return (int)(screen.width * cam.rect.width);
//		}
//	}
	
//	public static int xoffset {
//		get {
//			return (int)(screen.width * cam.rect.x);
//		}
//	}
	
//	public static int yoffset {
//		get {
//			return (int)(screen.height * cam.rect.y);
//		}
//	}
	
//	public static rect screenrect {
//		get {
//			return new rect(cam.rect.x * screen.width, cam.rect.y * screen.height, cam.rect.width * screen.width, cam.rect.height * screen.height);
//		}
//	}
	
//	public static vector3 mouseposition {
//		get {
//			vector3 mousepos = input.mouseposition;
//			mousepos.y -= (int)(cam.rect.y * screen.height);
//			mousepos.x -= (int)(cam.rect.x * screen.width);
//			return mousepos;
//		}
//	}
	
//	public static vector2 guimouseposition {
//		get {
//			vector2 mousepos = event.current.mouseposition;
//			mousepos.y = mathf.clamp(mousepos.y, cam.rect.y * screen.height, cam.rect.y * screen.height + cam.rect.height * screen.height);
//			mousepos.x = mathf.clamp(mousepos.x, cam.rect.x * screen.width, cam.rect.x * screen.width + cam.rect.width * screen.width);
//			return mousepos;
//		}
//	}
}