using UnityEngine;
using System.Collections;
using System;
using System.Drawing;
using System.IO;
#if UNITY_EDITOR
public class DebugScreenshot : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.F12)) {
            StartCoroutine(TakeScreenshot());
        }
    }

    public static IEnumerator TakeScreenshot() {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/DEBUG " + DateTime.Now.ToString("yMd Hms f") + ".jpg";

        Application.CaptureScreenshot(path);

        yield return new WaitForFixedUpdate();

        var filePath = path;
        Bitmap bitmap = null;

        // Create from a stream so we don't keep a lock on the file.
        using (var stream = File.OpenRead(filePath)) {
            bitmap = (Bitmap)Bitmap.FromStream(stream);
        }

        using (bitmap)
        using (var graphics = System.Drawing.Graphics.FromImage(bitmap))
        using (var font = new System.Drawing.Font("Arial", 20, System.Drawing.FontStyle.Regular)) {
            // Do what you want using the Graphics object here.

            Vector3 actualLocation = GenericDebug.GetPlayerLocation();
            string location = "Location: x;" + actualLocation.x + " y;" + actualLocation.y + " z;" + actualLocation.z;

            graphics.FillRectangle(Brushes.Black, 0, 0, 1024, 50);
            graphics.DrawString(location + " - Scene: " + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, font, Brushes.White, 0, 0);

            // Important part!
            bitmap.Save(filePath);
        }
        yield break;
    }

}
#endif