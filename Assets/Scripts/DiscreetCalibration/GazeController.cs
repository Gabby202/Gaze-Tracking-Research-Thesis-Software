using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;


public class GazeController : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] public float rollTiltLeftThreshold = 0.1f;
    [Range(0, 1)] [SerializeField] public float rollTiltRightThreshold = 0.1f;
    [Range(0, 1)] [SerializeField] public float pitchtiltUpThreshold = 0.55f;
    [Range(0, 1)] [SerializeField] public float pitchtiltDownThreshold = 0.7f;


    public float roll;
    public float pitch;
    public bool left, right, up, down = false;

    public GazeData gazeDataObject = new GazeData();
    void Start()
    {
        //gazeDataObject.head = -1;
        gazeDataObject.roll = -1;
        gazeDataObject.pitch = -1;
        StartCoroutine(GetText());

    }

    public IEnumerator GetText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/fetchData"))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    //Debug.Log(www.error);
                }
                else
                {
                    string jsonDataReceived = www.downloadHandler.text;
                    int pos = jsonDataReceived.IndexOf("}");
                    jsonDataReceived = jsonDataReceived.Substring(0, pos + 1);
                    //jsonDataReceived = jsonDataReceived.
                    //Debug.Log(jsonDataReceived);
                    GazeData gazeDataObject2 = new GazeData();
                    try
                    {
                        gazeDataObject2 = JsonUtility.FromJson<GazeData>(jsonDataReceived);
                    }
                    catch (System.Exception e)
                    {
                        //Debug.LogError(jsonDataReceived);
                    }

                    //if empty obj, use previous
                    if (null != gazeDataObject2)
                    {
                        gazeDataObject = gazeDataObject2;
                    }

                    this.roll = gazeDataObject.roll;
                    this.roll = gazeDataObject.pitch;

                    left = this.IsTiltingLeft();
                    right = this.IsTiltingRight();
                    up = this.IsTiltingUp();
                    down = this.IsTiltingDown();
                }
            }
        }
    }



    public bool IsTiltingLeft()
    {
        return this.gazeDataObject.roll > rollTiltLeftThreshold;
    }

    public bool IsTiltingRight()
    {
        return this.gazeDataObject.roll < -rollTiltRightThreshold;
    }

    public bool IsTiltingUp()
    {
        return this.gazeDataObject.pitch < pitchtiltUpThreshold;

    }

    public bool IsTiltingDown()
    {
        return this.gazeDataObject.pitch > pitchtiltDownThreshold;
    }

    public float GetRollValue()
    {
        //if (this.gazeDataObject.roll > rollTiltLeftThreshold && this.gazeDataObject.roll < rollTiltRightThreshold)
        if (IsTiltingLeft() || IsTiltingRight())
            return this.gazeDataObject.roll;
        return 0;
    }

    public float GetPitchValue()
    {
        if (IsTiltingDown() || IsTiltingUp())
            return this.gazeDataObject.pitch;
        return 0;
    }

    public float getRollValueForAxis()
    {
        if (this.IsTiltingLeft())
        {
            return -1.0f;
        }
        if (IsTiltingRight())
        {
            return 1.0f;
        }
        return 0.0f;
    }

    public float getPitchValueForAxis()
    {
        if (this.IsTiltingUp())
        {
            return 1.0f;
        }
        if (IsTiltingDown())
        {
            return -1.0f;
        }
        return 0.0f;
    }

    public float getRollValueForCarAxis()
    {
        if (this.IsTiltingLeft())
        {
            return -1.0f;
        }
        if (IsTiltingRight())
        {
            return 1.0f;
        }
        return 0.0f;
    }


    public float getPitchValueForCarAxis()
    {
        if (IsTiltingDown())
        {
            return -1.0f;
        }
        return 1.0f;
    }

}

