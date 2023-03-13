import numpy as np

def PrintMatrixFloat(matrix):

    for y in range(0, matrix.shape[0]):

        for x in range(0, matrix.shape[1]):

            print(f"( {matrix[y][x][0]:4.1f}, {matrix[y][x][1]:4.1f} )", end='')

        print()

def PrintMatrixInt(matrix):

    for y in range(0, matrix.shape[0]):

        for x in range(0, matrix.shape[1]):

            print(f"( {matrix[y][x][0]:2}, {matrix[y][x][1]:2} )", end='')

        print()

###############################################################################

# mY = int(input("Input matrix Height: "))
# mX = int(input("Input matrix Width: "))

mY, mX = 3, 7

im = np.array(np.zeros((mY, mX, 2)), int)

for y in range(0, mY):

    for x in range(0, mX):

        im[y][x] = [x + 1, y + 1]

print(); print('Base Matrix:'); PrintMatrixInt(im); print();

###############################################################################

# if (bool(input('Calculate Resized Matrix? (Enter - NO, Another - YES): '))):
if (False):

    rx = float(input("Input resize Width coefficient (Base Matrix Width *= coefficient): "))
    ry = float(input("Input resize Height coefficient (Base Matrix Height *= coefficient): "))

    resize = np.array(([rx, 0], [0, ry]))

    imResized = np.array(im)

    for y in range(0, mX):

        imResized[y] = np.matmul(im[y], resize)

    print(); PrintMatrixInt(imResized)

###############################################################################


imRotated = []

print('Input Rotation Point Coordinates (Default is Matrix Center)? (Enter - NO, Another - YES): ', end='')

# if (bool(input())):
if (False):

    rpx = int((input("Input Rotation Point X coordinate: ")))
    rpy = int((input("Input Rotation Point Y coordinate: ")))

else:

    rpx = int(np.round(mX / 2));
    rpy = int(np.round(mY / 2));

print(f"Rotation Point is ( {rpx}, {rpy} )")

rotatePoint = [rpx, rpy];

# angle = np.radians(int(input("Input Rotation Angle in degrees: ")));

angle = np.radians(-45)

minX, minY, maxX, maxY = 1, 1, 1, 1;

###############################################################################

ccos = np.cos(angle)
csin = np.sin(angle)


for y in range(0, mY):

    for x in range(0, mX):

        # Info taken from https://ip76.ru/short-stories/rect-no-center-rotate/

        # O (x0, y0) - Rotation Center Point 
        # x' = (x - x0) * cos(alpha) - (y - y0) * sin(alpha) + x0
        # y' = (x - x0) * sin(alpha) + (y - y0) * cos(alpha) + y0
        X = (im[y][x][0] - rotatePoint[0]) * ccos - (im[y][x][1] - rotatePoint[1]) * csin + rotatePoint[0]
        Y = (im[y][x][0] - rotatePoint[0]) * csin + (im[y][x][1] - rotatePoint[1]) * ccos + rotatePoint[1]

        if X < minX: minX = X
        if Y < minY: minY = Y

        if X > maxX: maxX = X
        if Y > maxY: maxY = Y

        imRotated.append([X, Y])


###############################################################################

print(); print(f"Base Matrix size: {mY} x {mX}"); PrintMatrixInt(im)

buff1 = imRotated[-1]
buff2 = imRotated[0]

newSizeX = int(np.round(buff1[0] - buff2[0]) + 1)
newSizeY = int(np.round(buff1[1] - buff2[1]) + 1)

imRotated = np.reshape(np.array(imRotated, float), (newSizeY, newSizeX, 2))

print(); print(f"Rotation angle: {np.degrees(angle)} degrees") 
print(f"Rotated Matrix size: {int(newSizeY)} x {int(newSizeX)}"); PrintMatrixFloat(imRotated)


print(); print(f'MinX: {minX:.3f}, MinY: {minY:.3f}')
print(f'MaxX: {maxX:.3f}, MaxY: {maxY:.3f}')