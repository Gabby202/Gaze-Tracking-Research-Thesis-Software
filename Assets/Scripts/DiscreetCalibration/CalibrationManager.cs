using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationManager : MonoBehaviour {

    private int n = 0;
    private GazeController gazeController;
    public List<GameObject> squares;
    private SquareController squareController;

    // Use this for initialization
    void Start () {
        gazeController = GetComponent<GazeController>();
        squareController = GetComponent<SquareController>();
        squares = new List<GameObject>();

    }

    void Update()
    {

        if (gazeController.IsTiltingUp())
        {
            n = 0;
            MakeGreen(n);
        }
        if (gazeController.IsTiltingLeft())
        {
            n = 1;
            MakeGreen(n);
        }
        if (gazeController.IsTiltingDown())
        {
            n = 2;
            MakeGreen(n);
        }
        if (gazeController.IsTiltingRight())
        {
            n = 3;
            MakeGreen(n);
        }
        if (gazeController.IsTiltingUp() && gazeController.IsTiltingRight())
        {
            n = 4;
            MakeGreen(n);

        }
        if (gazeController.IsTiltingUp() && gazeController.IsTiltingLeft())
        {
            n = 5;
            MakeGreen(n);

        }
        if (gazeController.IsTiltingDown() && gazeController.IsTiltingRight())
        {
            n = 6;
            MakeGreen(n);

        }
        if (gazeController.IsTiltingDown() && gazeController.IsTiltingLeft())
        {
            n = 7;
            MakeGreen(n);

        }
        else
        {
            n = -1;
            MakeGreen(n);

        }




        //Debug.Log("n = " + n);
        //n = -1;
    }

    private void MakeGreen(int n)
    {
        if (n == squareController.targetImage)
        {
            //Debug.Log("Numbers Match!");
            squareController.MakeSquargreen(n);
        }
    }




}
