import numpy as np

def PrintMatrix(matrix):

    for i in range(0, matrix.shape[0]):

        for j in range(0, matrix.shape[1]):

            print(f"({matrix[i][j][0]:6.3f}, {matrix[i][j][1]:6.3f})", end='')

        print()


mY = int(4)
mX = int(4)

im = []

for i in range(1, mX + 1):

    for j in range(1, mY + 1):

        im.append([i, j])

im = np.reshape(np.array(im, int), (mX, mY, 2))


PrintMatrix(im)

angle = 90;
resize = np.array(([2, 0], [0, 1.5]))
rotate = np.array(([np.cos(angle), np.sin(angle)], [-np.sin(angle), np.cos(angle)]), float)

imResized = np.array(im)
imRotated = []

rotatePoint = (mX / 2, mY / 2);

for i in range(0, mX):

    for j in range(0, mY):

        imResized[i] = np.matmul(im[i], resize)

        X = float((im[i][j][0] - rotatePoint[0]) * np.cos(angle) - (im[i][j][1] - rotatePoint[1]) * np.sin(angle) + rotatePoint[0])
        Y = float((im[i][j][0] - rotatePoint[0]) * np.sin(angle) + (im[i][j][1] - rotatePoint[1]) * np.sin(angle) + rotatePoint[1])

        imRotated.append([X, Y])


imRotated = np.reshape(np.array(imRotated, float), (mX, mY, 2))

print(); print(); PrintMatrix(imResized)
print(); print(); PrintMatrix(imRotated)