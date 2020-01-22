using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SquareController : MonoBehaviour {

    private GameObject upImage, leftImage, downImage, rightImage, upRightImage, upLeftImage, downRightImage, downLeftImage;
    public List<GameObject> images;
    public int n = 0;
    public int targetImage = 0;
    private int completeCount = 0;
    public Text text;
    
    // Use this for initialization
    void Start () {
        images = new List<GameObject>();
        upImage = GameObject.Find("Up Image");
        images.Add(upImage);
        leftImage = GameObject.Find("Left Image");
        images.Add(leftImage);
        downImage = GameObject.Find("Down Image");
        images.Add(downImage);
        rightImage = GameObject.Find("Right Image");
        images.Add(rightImage);
        upRightImage = GameObject.Find("UpRight Image");
        images.Add(upRightImage);
        upLeftImage = GameObject.Find("UpLeft Image");
        images.Add(upLeftImage);
        downRightImage = GameObject.Find("DownRight Image");
        images.Add(downRightImage);
        downLeftImage = GameObject.Find("DownLeft Image");
        images.Add(downLeftImage);
        completeCount = images.Count;
        InvokeRepeating("NextSquare", 0, 3);

    }


    //public void SelectSquare(int n)
    //{
    //    foreach (GameObject image in images)
    //    {
    //        if (image.GetComponent<RawImage>().color == Color.green)
    //        {
    //            images.Remove(image);
    //        }
    //        image.GetComponent<RawImage>().color = Color.gray;
    //    }

    //    //upImage.GetComponent<RawImage>().color = Color.gray;
    //    //downImage.GetComponent<RawImage>().color = Color.gray;
    //    //leftImage.GetComponent<RawImage>().color = Color.gray;
    //    //rightImage.GetComponent<RawImage>().color = Color.gray;
    //    //upRightImage.GetComponent<RawImage>().color = Color.gray;
    //    //downRightImage.GetComponent<RawImage>().color = Color.gray;
    //    //upLeftImage.GetComponent<RawImage>().color = Color.gray;
    //    //downLeftImage.GetComponent<RawImage>().color = Color.gray;

    //    switch (n)
    //    {
    //        case 0:
    //            targetSquare = TargetSquare.UpLeft;
    //            break;
    //        case 1:
    //            targetSquare = TargetSquare.Left;
    //            break;
    //        case 2:
    //            targetSquare = TargetSquare.DownLeft;
    //            break;
    //        case 3:
    //            targetSquare = TargetSquare.Up;
    //            break;
    //        case 4:
    //            targetSquare = TargetSquare.Down;
    //            break;
    //        case 5:
    //            targetSquare = TargetSquare.UpRight;
    //            break;
    //        case 6:
    //            targetSquare = TargetSquare.Right;
    //            break;
    //        case 7:
    //            targetSquare = TargetSquare.DownRight;
    //            break;
            
    //    }
    //    ColorSquare(n, Color.yellow);
    //}

    public void ColorSquare(int n, Color color)
    {
        //Debug.Log("ColorSquare Called...");



        for (int i = 0; i < images.Count; i++)
        {

            if (images[i].GetComponent<RawImage>().color != Color.green)
            {
                images[i].GetComponent<RawImage>().color = Color.gray;
            } 
        }

        if (images[n].GetComponent<RawImage>().color != Color.green)
        {
            images[n].GetComponent<RawImage>().color = color;
            targetImage = n;
            Debug.Log("targetImage = " + targetImage);
        } else
        {
            //completeCount = 0;
            foreach(GameObject image in images)
            {
                if (image.GetComponent<RawImage>().color != Color.green)
                {
                    completeCount++;
                }
                if(completeCount == 8)
                {
                    //text.text = "COMPLETE";
                    //text.color = Color.green;
                    //new WaitForSeconds(2);
                    //text.text = "new scene";

                    //SceneManager.LoadScene("CompleteScene");

                }
            }
            //Debug.Log(completeCount);
            NextSquare();
        }


        
        

    }

    public void MakeSquargreen(int index)
    {
        images[n].GetComponent<RawImage>().color = Color.green;

        
    }

    private void NextSquare()
    {
        //Debug.Log("NextSquare() Called...");
        n = Random.Range(0, images.Count);
        ColorSquare(n, Color.yellow);
        
    }

}
