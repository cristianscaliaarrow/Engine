using UnityEngine;
using System.Collections;

public class SingletonClass<T> : MonoBehaviour where T :MonoBehaviour {

    public static T instance;

	public virtual void Awake () {
        if (instance == null){
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	

}
