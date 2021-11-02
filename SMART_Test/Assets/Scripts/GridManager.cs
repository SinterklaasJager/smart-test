using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject gridCube, playerObj;
    [SerializeField] private int maxGridZ, maxGridX;
    private bool moving = false;
    private Grid grid;
    private CatRotation catRotation;

    private Vector3Int currentPlayerPosition;
    void Start()
    {
        grid = gameObject.GetComponent<Grid>();
        grid.transform.position = new Vector3(-0.35f, 0, -0.63f);

        for (int i = 0; i < maxGridX; i++)
        {
            for (int j = 0; j < maxGridZ; j++)
            {
                Instantiate(gridCube, grid.GetCellCenterLocal(new Vector3Int(i, 0, j)), Quaternion.identity, transform);
            }
        }

        playerObj = Instantiate(playerObj, grid.GetCellCenterLocal(new Vector3Int(0, 1, 0)), Quaternion.identity);
        catRotation = playerObj.GetComponent<CatRotation>();
        currentPlayerPosition = new Vector3Int(0, 1, 0);

    }

    void Update()
    {
        if (!moving)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow) && currentPlayerPosition.z < maxGridZ - 1)
            {
                currentPlayerPosition.z = currentPlayerPosition.z + 1;
                playerObj.transform.position = grid.GetCellCenterLocal(currentPlayerPosition);
                catRotation.UpdateRotation(CatAngle.forwards);

            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && currentPlayerPosition.z >= 1)
            {
                currentPlayerPosition.z = currentPlayerPosition.z - 1;
                playerObj.transform.position = grid.GetCellCenterLocal(currentPlayerPosition);
                catRotation.UpdateRotation(CatAngle.backwards);

            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) && currentPlayerPosition.x >= 1)
            {
                currentPlayerPosition.x = currentPlayerPosition.x - 1;
                playerObj.transform.position = grid.GetCellCenterLocal(currentPlayerPosition);
                catRotation.UpdateRotation(CatAngle.left);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && currentPlayerPosition.x < maxGridX - 1)
            {
                currentPlayerPosition.x = currentPlayerPosition.x + 1;
                playerObj.transform.position = grid.GetCellCenterLocal(currentPlayerPosition);
                catRotation.UpdateRotation(CatAngle.right);
            }
        }

    }
}
