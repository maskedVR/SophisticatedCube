using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace SophisticatedCube
{
    [BepInPlugin("com.ngbatz.gorillatag.sophisticatedcube", "SophisticatedCube", "1.0.1")]
	public class Plugin : BaseUnityPlugin
	{
		public static Plugin instance;
        public static AssetBundle bundle;
        public static GameObject assetBundleParent;
        public static string assetBundleName = "grabbbbb";
        public static string parentName = "BundleParent (put objects in here DONT MOVE)";

		public void Start()
		{
			instance = this;
			bundle = LoadAssetBundle("SophisticatedCube.AssetBundles." + assetBundleName);
            assetBundleParent = Instantiate(bundle.LoadAsset<GameObject>(parentName));
            assetBundleParent.transform.position = new Vector3(-67.2225f, 11.57f, -82.611f);
            GameObject cube = GameObject.Find("grabbable");
            cube.AddComponent<Rigidbody>();
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            cube.AddComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>();
            int gorillaTriggerLayer = LayerMask.NameToLayer("Gorilla Trigger");
            if (gorillaTriggerLayer != -1)
            {
                cube.layer = gorillaTriggerLayer;
            }
        }

        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
    }
}
