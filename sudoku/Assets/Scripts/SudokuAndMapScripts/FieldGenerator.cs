/* define instatiate globle position */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GenerateSudoku generateSudoku;

     public GameObject[,] board;

    public GameObject gridPrefab;
    private GameObject tempGameObject;

    float gridPrefabXScale = 0;
    float gridPrefabYScale = 0;

    public int gridWidth = 10;
    public int gridHeight = 10;

    public float xPedding = 0;
    public float yPedding = 0;

    float xPos = 0;
    float yPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("fiedl gen");
        if (gridPrefab)
        {
            board = new GameObject[gridWidth,gridHeight];

            gridPrefabXScale = gridPrefab.transform.localScale.x;
            gridPrefabYScale = gridPrefab.transform.localScale.y;

            xPedding += gridPrefabXScale;
            yPedding += gridPrefabYScale;

            CreateArea();
        }
    }

    void CreateArea()
    {
        int count = 0;
        if (gridWidth % 2 == 1)
        {
            for (int i = 0; i < gridHeight; i++)
            {
                count = 0;
                tempGameObject = Instantiate(gridPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                tempGameObject.name = "square" + i + "-0";
                tempGameObject.transform.SetParent(gameObject.gameObject.transform);
                board[i, 0] = tempGameObject;
                board[i, 0].GetComponent<GridScript>().trueValue = 0;
                for (int j = 0; j < (gridWidth/2); j++)
                {
                    xPos += xPedding;
                    count++;
                    tempGameObject = Instantiate(gridPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    tempGameObject.name = "square" + i + "-" + (j+count);
                    tempGameObject.transform.SetParent(gameObject.gameObject.transform);
                    board[i, j + count] = tempGameObject;
                    board[i, 0].GetComponent<GridScript>().trueValue = 0;

                    tempGameObject = Instantiate(gridPrefab, new Vector3(-xPos, yPos, 0), Quaternion.identity);
                    tempGameObject.name = "square" + i + "-" + (j+count+1);
                    tempGameObject.transform.SetParent(gameObject.gameObject.transform);
                    board[i, (j + count + 1)] = tempGameObject;
                    board[i, 0].GetComponent<GridScript>().trueValue = 0;

                }
                if (i < gridHeight / 2)
                {
                    yPos += yPedding;
                }
                else if(i > gridHeight / 2)
                {
                    yPos -= yPedding;
                }else  if(i == gridHeight / 2)
                {
                    yPos = -yPedding;
                }

                xPos = 0;
            }
        }
        else
        {
            for (int i = 0; i < gridHeight; i++)
            {
                count = 0;
                xPos += xPedding / 2;
                if (i < gridHeight / 2)
                {
                    yPos += yPedding;
                }
                else if (i > gridHeight / 2)
                {
                    yPos -= yPedding;
                }
                else if (i == gridHeight / 2)
                {
                    yPos = -yPedding;
                }
                if (i == 0) yPos -= yPedding; 
                for (int j = 0; j < (gridWidth / 2); j++)
                {
                    count++;
                    tempGameObject = Instantiate(gridPrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);
                    tempGameObject.name = "square" + i+"-" + (j + count);
                    tempGameObject.transform.SetParent(gameObject.gameObject.transform);
                    board[i, (j + count)] = tempGameObject;
                    board[i, 0].GetComponent<GridScript>().trueValue = 0;

                    tempGameObject = Instantiate(gridPrefab, new Vector3(-xPos, yPos, 0), Quaternion.identity);
                    tempGameObject.name = "square" + i + "-" + (j + count + 1);
                    tempGameObject.transform.SetParent(gameObject.gameObject.transform);
                    board[i, (j + count + 1)] = tempGameObject;
                    board[i, 0].GetComponent<GridScript>().trueValue = 0;

                    xPos += xPedding;

                }
                

                xPos = 0;
            }
        }
        AdjustCameraAccordingToMap();
    }

    void AdjustCameraAccordingToMap()
    {
        float mapWidthLength = (gridWidth + 1) * xPedding;
        float t = 0;
        t = ((Screen.dpi / 100) * (Screen.width / Screen.dpi));
        t += mapWidthLength + 8;
        Debug.Log("sonuc " + t);
        Camera.main.GetComponent<ViewportHandler>().UnitsSize = t;

        generateSudoku.startGenerating = true;
    }
}
