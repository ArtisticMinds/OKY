using System;
using UnityEngine;


    public class FollowTarget : MonoBehaviour
    {

        public Axis axis = Axis.All;
        public enum Axis
        {
            X, Y, Z,All
        }
        public bool smooth = false;
        public float smooting = 2;
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);

        public bool FollowAsChildren;

        Vector3 OrPosition;
        private void Awake()
        {
            if (FollowAsChildren) OrPosition = transform.localPosition;
        }

        private void LateUpdate()
        {


            if (FollowAsChildren)
            {
                transform.localRotation = target.localRotation;
                transform.localPosition = OrPosition + target.localPosition;
                return;
            }

            if (smooth) {


                if (axis == Axis.All)
                    transform.position = target.position + offset;
                else if (axis == Axis.X)
                    transform.position = Vector3.Lerp(transform.position,( new Vector3(target.position.x, transform.position.y, transform.position.z) + offset),Time.deltaTime*smooting);
                else if (axis == Axis.Y)
                    transform.position = Vector3.Lerp(transform.position, (new Vector3(transform.position.x, target.position.y, transform.position.z) + offset), Time.deltaTime * smooting);
                else if (axis == Axis.Z)
                    transform.position = Vector3.Lerp(transform.position, (new Vector3(transform.position.x, transform.position.y, target.position.z) + offset), Time.deltaTime * smooting);

            }
            else
            {


                if (axis == Axis.All)
                    transform.position = target.position + offset;
                else if (axis == Axis.X)
                    transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z) + offset;
                else if (axis == Axis.Y)
                    transform.position = new Vector3(transform.position.x, target.position.y, transform.position.z) + offset;
                else if (axis == Axis.Z)
                    transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z) + offset;


            }
        }
    }

