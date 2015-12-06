using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ExceptionTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FileStream file = null;
        FileInfo fileInfo = null;

        try
        {
            fileInfo = new FileInfo("file.txt");
            file = fileInfo.OpenWrite();

            for(int i = 0; i < 255; i++)
            {
                file.WriteByte((byte)i);
            }

            throw new ArgumentNullException("Something bad happened.");
        }
        catch(UnauthorizedAccessException e)
        {
            Debug.LogWarning(e.Message);
        }

        catch (ArgumentNullException e)
        {
            //Debug.LogWarning(e.Message);
            Debug.LogWarning("BAD!!!");
        }
        finally
        {
            if (file != null)
                file.Close();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
