import numpy as np

def PrintMatrix(matrix):

    for i in range(0, matrix.shape[0]):

        for j in range(0, matrix.shape[1]):

            print(f"({im[i][j][0]},{im[i][j][1]})", end='')

        print()


mY = 4
mX = 4

im = []

for i in range(1, mX + 1):

    for j in range(1, mY + 1):

        im.append([i, j])

im = np.array(im, float)

im = np.reshape(im, (mX, mY, 2))


PrintMatrix(im)

resize = np.array(([2, 0], [0, 1.5]), float)

for i in range(0, mX):

    for j in range(0, mY):

        im[i][j] = np.matmul(im[i][j], resize)

print()
print()
PrintMatrix(im)

print()
input("Program is ended")

    
