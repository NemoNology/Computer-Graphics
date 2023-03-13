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

###############################################################################

mX = int(input("Input matrix Height: "))
mY = int(input("Input matrix Width: "))

im = np.array(np.zeros((mX, mY, 2)), int)

for i in range(0, mX):

    for j in range(0, mY):

        im[i][j] = [i + 1, j + 1]

print(); print('Base Matrix:'); PrintMatrixInt(im); print();

###############################################################################

if (bool(input('Calculate Resized Matrix? (Enter - NO, Another - YES): '))):

    rx = float(input("Input resize Width coefficient (Base Matrix Width *= coefficient): "))
    ry = float(input("Input resize Height coefficient (Base Matrix Height *= coefficient): "))

    resize = np.array(([rx, 0], [0, ry]))

    imResized = np.array(im)

    for i in range(0, mX):

        imResized[i] = np.matmul(im[i], resize)

    print(); PrintMatrixInt(imResized)

###############################################################################


imRotated = []

print('Input Rotation Point Coordinates (Default is Matrix Center)? (Enter - NO, Another - YES): ', end='')

if (bool(input())):

    rpx = int((input("Input Rotation Point X coordinate: ")))
    rpy = int((input("Input Rotation Point Y coordinate: ")))

else:

    rpx = int(np.round(mX / 2));
    rpy = int(np.round(mY / 2));

print(f"Rotation Point is ( {rpx}, {rpy} )")

rotatePoint = (rpx, rpy);

angle = np.radians(int(input("Input Rotation Angle in degrees: ")));

minX, minY = 1, 1;

maxX, maxY = int(mX), int(mY);

###############################################################################


for i in range(0, mX):

    for j in range(0, mY):

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


###############################################################################

print(); print(f"Base Matrix size: {mX} x {mY}"); PrintMatrixInt(im)

imRotated = np.reshape(np.array(imRotated, float), (mX, mY, 2))

print(); print(f"Rotation angle: {np.degrees(angle)} degrees") 
print(f"Rotated Matrix size: {maxX - minX} x {maxY} - NOT TRUE!"); PrintMatrixFloat(imRotated)


print(); print(f'MinX: {minX:.3f}, MinY: {minY:.3f}')
print(f'MaxX: {maxX:.3f}, MaxY: {maxY:.3f}')
print(f'New size: {int(maxX - minX) + 1} x {int(maxY - minY) + 1}')