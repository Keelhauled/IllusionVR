﻿using UnityEngine;

namespace VRGIN.Core
{
    public class Marker : MonoBehaviour
    {
    }
    /// <summary>
    /// Default actor that is defined by a Unity behaviour.
    /// </summary>
    /// <typeparam name="T">Type of the MonoBehaviour</typeparam>
    public abstract class DefaultActor<T> : IActor where T : MonoBehaviour
    {


        public T Actor { get; protected set; }

        public DefaultActor(T nativeActor)
        {
            Actor = nativeActor;

            Initialize(nativeActor);
        }

        public virtual bool IsValid => Actor;

        public abstract Transform Eyes
        {
            get;
        }


        public abstract bool HasHead
        {
            get;
            set;
        }

        protected virtual void Initialize(T actor)
        {
            Actor.gameObject.AddComponent<Marker>();
        }

        public static bool IsAlreadyMapped(T nativeActor)
        {
            return nativeActor.GetComponent<Marker>();
        }
    }
}
