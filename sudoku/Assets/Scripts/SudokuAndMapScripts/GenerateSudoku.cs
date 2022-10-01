using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;

public class GenerateSudoku : MonoBehaviour
{
    FieldGenerator fieldGenerator; 

    int[] randomValue1to9 = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    int[,] tempBoard;
    int gridWidth = 0;
    int gridHeight = 0;
    public bool startGenerating = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start??");

        fieldGenerator = GameObject.Find("Field").GetComponent<FieldGenerator>();
        startGenerating = false;
        gridWidth = fieldGenerator.gridWidth;
        gridHeight = fieldGenerator.gridHeight;

        Debug.Log("suffla");
        ShuffleArray(randomValue1to9);
        for (int i = 0; i < randomValue1to9.Length; i++)
        {
            Debug.Log("randomValue1to9 " + randomValue1to9);
        }
        CreateBoard(tempBoard);
    }

    private void Update()
    {
        Debug.Log("ananas");
         if (startGenerating)
         { 
         /*   fieldGenerator.board[0, 0].GetComponent<GridScript>().trueValue = 5;

            //CreateBoard(fieldGenerator.board);
            printArr(tempBoard);
            startGenerating = false;*/
         }
    }
    void printArr(int [,]board)
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Debug.Log(i+"-"+j + " => " + board[i,j]);
            }
        }
    }
    bool IsNumberInRow(int[,] board, int number, int row)
    {
        for (int i = 0; i < gridWidth; i++)
        {
            if (board[row,i] == number)
            {
                return true;
            }
        }
        return false;
    }

    bool IsNumberInColumn(int[,] board, int number, int column)
    {
        for (int i = 0; i < gridHeight; i++)
        {
            if (board[i, column] == number)
            {
                return true;
            }
        }
        return false;
    }

    bool IsNumberInBox(int[,] board, int number, int row, int column)
    {
        int localBoxRow = row - row % 3;
        int localBoxColumn = column - column % 3;

        for (int i = localBoxRow; i < localBoxRow + 3; i++)
        {
            for (int j = localBoxColumn; j < localBoxColumn + 3; j++)
            {
                if (board[i, j] == number)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool IsValidPlacement(int[,] board,int number, int row, int column)
    {
        return !IsNumberInRow(board, number, row) &&
            !IsNumberInColumn(board, number, column) &&
            !IsNumberInBox(board, number, row, column);
    }

    public bool CreateBoard(int [,]board)
    {
       /* for (int row = 0; row < gridWidth; row++)
        {
            for (int column = 0; column < gridHeight; column++)
            {
                if (board[row, column] == 0)
                {
                    for (int i = 0; i < gridWidth; i++)
                    {
                        if (IsValidPlacement(board, randomValue1to9[i], row, column))
                        {
                            board[row, column] = randomValue1to9[i];
                            Debug.Log("evet " + fieldGenerator.board[0, 0].GetComponent<GridScript>().trueValue);

                            if (CreateBoard(board))
                            {
                                return true;
                            }
                            else
                            {
                                board[row, column] = 0;
                            }
                        }
                    }
                    return false;
                }
            }
        }*/
        return true;
    }


    void ShuffleArray(int []arr)
    {
        int tempInt;
        for (int i = 0; i < arr.Length; i++)
        {
            int rnd = Random.Range(0, arr.Length);
            tempInt = arr[rnd];
            arr[rnd] = arr[i];
            arr[i] = tempInt;
        }
        return;
    }
}
