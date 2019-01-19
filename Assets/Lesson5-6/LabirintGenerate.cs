using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains.Editor
{
    public class LabirintGenerate : MonoBehaviour
    {

        public GameObject Prefub;
        public float placementThreshold = .2f; //коэфициент разряжености
        public int sizeRows;
        public int sizeColumns;


        private int[,] data;

        public void ObjGenerate(GameObject wallprefub, int rows, int columns)
        {
            GameObject root = new GameObject("LabirintRoot");
            data = FromDimensions(rows, columns);
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] != 0)
                    {
                        GameObject Temp = Instantiate(wallprefub, new Vector3(i, 0, j), Quaternion.identity);
                        Temp.transform.parent = root.transform;
                        Temp.tag = "Wall";
                    }
                }
            }
        }

        public int[,] FromDimensions(int sizeRows, int sizeCols)
        {
            int[,] maze = new int[sizeRows, sizeCols];

            int rMax = maze.GetUpperBound(0);
            int cMax = maze.GetUpperBound(1);

            for (int i = 0; i <= rMax; i++)
            {
                for (int j = 0; j <= cMax; j++)
                {
                    if (i == 0 || j == 0 || i == rMax || j == cMax)
                    {
                        maze[i, j] = 1;
                    }

                    else if (i % 2 == 0 && j % 2 == 0)
                    {
                        if (Random.value > placementThreshold)
                        {
                            maze[i, j] = 1;
                            int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                            int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                            maze[i + a, j + b] = 1;
                        }
                    }
                }
            }

            return maze;
        }
    }
}
