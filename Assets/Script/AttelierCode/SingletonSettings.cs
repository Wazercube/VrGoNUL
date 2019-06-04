using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SingletonSettings<TSingletonType> : ScriptableObject
    where TSingletonType : ScriptableObject
{ 
    

    private static TSingletonType _instance = null;

    public static TSingletonType Instance
    {
        get
        {
            if(_instance == null)
            {
                TSingletonType[] sttingsAsset = Resources.FindObjectsOfTypeAll<TSingletonType>();

                if(sttingsAsset.Length == 1)
                {
                    _instance = sttingsAsset[0];
                }
                else if(sttingsAsset.Length>1)
                {
                    Debug.LogWarning("There's more than one asset of type ");
                    _instance = sttingsAsset[0];
                }
                else
                {
                    Debug.LogWarning("There's no asset of type ");
                    _instance =  ScriptableObject.CreateInstance<TSingletonType>();
                }
                
            }
            return _instance;
        }

    }
	
}
