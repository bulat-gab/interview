from typing import Dict, List, Tuple
import math

def rotate(matrix: List[List[str]]) -> List[List[str]]:
    new_m = []

    for i in range(len(matrix)):
        new_row = []
        for j in range(len(matrix[i])-1, -1, -1):
            new_row.append(matrix[j][i])
        new_m.extend([new_row])
    
    for row in new_m:
        for cell in row:
            print(cell, end=' ')
        print()

    return new_m


def rotate_inplace(m):
    n = len(m)
    x = math.floor(n / 2)
    y = n - 1

    for i in range(x):
        for j in range(i, y - i):

            temp = m[i][j]

            # left -> top
            m[i][j] = m[y - j][i]

            # bot -> left
            m[y - j][i] = m[y - i][y - i]

            # right -> bot
            m[y - i][y - i] = m[j][y - i]

            # top -> right
            m[j][y - i] = temp
    return m

def print_matrix(m):
    for row in m:
        for cell in row:
            print(cell, end=' ')
        print('\n')


m = [   ['*', '*', '*', '^', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
        ['*', '*', '*', '|', '*', '*', '*',],\
    ]

m3x3 = [
        ['1', '2', '3'],
        ['4', '5', '6'],
        ['7', '8', '9']
]

m4x4 = [
        ['1', '2', '3', '4'],
        ['5', '6', '7', '8'],
        ['9', '10', '11', '12'],
        ['13', '14', '15', '16']
]

# m_rotated = rotate_inplace(m)
# m3x3_rotated = rotate_inplace(m3x3)
m4x4_rotated = rotate_inplace(m4x4)

print_matrix(m4x4_rotated)