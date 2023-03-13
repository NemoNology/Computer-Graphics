import numpy as np

def PrintMatrixFloat(matrix):

    for i in range(0, matrix.shape[0]):

        for j in range(0, matrix.shape[1]):

            print(f"( {matrix[i][j][0]:.3f}, {matrix[i][j][1]:.3f} )", end='')

        print()

def PrintMatrixInt(matrix):

    for i in range(0, matrix.shape[0]):

        for j in range(0, matrix.shape[1]):

            print(f"( {matrix[i][j][0]}, {matrix[i][j][1]} )", end='')

        print()


mY = int(4)
mX = int(4)

im = []

for i in range(1, mX + 1):

    for j in range(1, mY + 1):

        im.append([j, i])

im = np.reshape(np.array(im, int), (mX, mY, 2))


# PrintMatrixInt(im)

angle = np.radians(90);

resize = np.array(([2, 0], [0, 1.5]))

imResized = np.array(im)
imRotated = []

# rotatePoint = (mX / 2, mY / 2);
rotatePoint = (0, 0);

minX = 1;   
minY = 1;

maxX = int(mX);
maxY = int(mY);

for i in range(0, mX):

    for j in range(0, mY):

        imResized[i] = np.matmul(im[i], resize)

        # Info taken from https://ip76.ru/short-stories/rect-no-center-rotate/

        # O (x0, y0) - Rotation Center Point 
        # x' = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0
        # y' = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0
        X = (im[i][j][0] - rotatePoint[0]) * np.cos(angle) - (im[i][j][1] - rotatePoint[1]) * np.sin(angle) + rotatePoint[0]
        Y = (im[i][j][0] - rotatePoint[0]) * np.sin(angle) + (im[i][j][1] - rotatePoint[1]) * np.cos(angle) + rotatePoint[1]

        if X < minX: minX = X
        if Y < minY: minY = Y

        if X > maxX: maxX = X
        if Y > maxY: maxY = Y

        imRotated.append([X, Y])


print(); PrintMatrixInt(im)

imRotated = np.reshape(np.array(imRotated, float), (mX, mY, 2))

print(); PrintMatrixInt(imResized)
print(); print(f"Rotation angle: {np.degrees(angle)} degrees"); PrintMatrixFloat(imRotated)


print(); print(f'MinX: {minX:.3f}, MinY: {minY:.3f}')
print(f'MaxX: {maxX:.3f}, MaxY: {maxY:.3f}')
print(f'New size: {int(maxX - minX) + 1} x {int(maxY - minY) + 1}')