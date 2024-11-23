using BepInEx;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace SophisticatedCube
{
    [BepInPlugin("com.ngbatz.gorillatag.sophisticatedcube", "SophisticatedCube", "1.0.0")]
    public class CubeMod : BaseUnityPlugin
    {
        void Start()
        {
            CreateCube();
        }

        void CreateCube()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Rigidbody rb = cube.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            XRGrabInteractable grabInteractable = cube.AddComponent<XRGrabInteractable>();
            Collider cubeCollider = cube.GetComponent<Collider>();
            if (cubeCollider == null)
            {
                cubeCollider = cube.AddComponent<BoxCollider>();
            }
            cubeCollider.isTrigger = true;
            int gorillaTriggerLayer = LayerMask.NameToLayer("Gorilla Trigger");
            if (gorillaTriggerLayer != -1)
            {
                cube.layer = gorillaTriggerLayer;
            }
            else
            {
                Logger.LogError("PENIS HEHAHEHHAEHEA");
            }

            var renderer = cube.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.green;
            }
        }
    }
}
