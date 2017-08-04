import matplotlib as mpl
import numpy as np
import matplotlib.pyplot as plt

def plot(file_name, x_label, y_label):
    x, y = np.loadtxt(file_name, delimiter=',', unpack=True)
    plt.plot(x, y)
    plt.xlabel(x_label)
    plt.ylabel(y_label)
    plt.title(x_label + " vs " + y_label)
    plt.legend()
    plt.show()

plot('HeadsetData_GroupMeeting8-4.csv', "Time", "Y Position")
