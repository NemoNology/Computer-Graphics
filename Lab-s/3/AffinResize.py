import numpy as np

def PrintMatrix(matrix):

    for i in range(0, matrix.shape[0]):

        for j in range(0, matrix.shape[1]):

            print(f"({im[i][j][0]},{im[i][j][1]})", end='')

        print()


mY = int(4)
mX = int(4)

im = []

for i in range(1, mX + 1):

    for j in range(1, mY + 1):

        im.append([i, j])

im = np.array(im, int)

im = np.reshape(im, (mX, mY, 2))


PrintMatrix(im)

angle = 90;

resize = np.array(([2, 0], [0, 1.5]), int)
rotate = np.array(([np.cos(angle), np.sin(angle)], [-np.sin(angle), np.cos(angle)]), float)

imResized = []
imRotated = np.array(im.shape, float)

rotatePoint = (mX / 2, mY / 2);

for i in range(0, mX):

    for j in range(0, mY):

        imResized[i][j] = np.matmul(im[i][j], resize)
        # imRotated[i][j] = im[i][j]  TODO: Rotation...

print()
print()
PrintMatrix(imResized)



print()
input("Program is ended")