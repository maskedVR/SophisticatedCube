using BepInEx;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

namespace SophisticatedCube
{
    [BepInPlugin("com.ngbatz.gorillatag.sophisticatedcube", "SophisticatedCube", "1.0.1")]
    public class CubeMod : BaseUnityPlugin
    {
        private GameObject cube;

        void Start()
        {
            CreateCube();
        }

        void Update()
        {
            if (ControllerInputPoller.instance.rightControllerPrimaryButton || UnityInput.Current.GetKey(KeyCode.E))
            {
                Teleport();
            }
        }

        void CreateCube()
        {
            cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = Vector3.zero;
            cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            Rigidbody rb = cube.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            XRGrabInteractable grabInteractable = cube.AddComponent<XRGrabInteractable>();
            Collider collider = cube.GetComponent<Collider>();
            if (collider == null)
            {
                collider = cube.AddComponent<BoxCollider>();
            }
            collider.isTrigger = true;
            int gorillaTriggerLayer = LayerMask.NameToLayer("Gorilla Trigger");
            if (gorillaTriggerLayer != -1)
            {
                cube.layer = gorillaTriggerLayer;
            }
            var renderer = cube.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.green;
            }
        }

        void Teleport()
        {
            if (Camera.main != null)
            {
                Vector3 forward = Camera.main.transform.forward;
                cube.transform.position = Camera.main.transform.position + forward * 0.5f;
            }
        }
    }
}
