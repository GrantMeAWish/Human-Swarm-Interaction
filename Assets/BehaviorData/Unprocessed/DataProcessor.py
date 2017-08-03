import matplotlib as mpl
import numpy as np
import matplotlib.pyplot as plt

def plot(file_name):
    x, y = np.loadtxt(file_name, delimiter=',', unpack=True)
    plt.plot(x, y)
    plt.xlabel('Time (s)')
    plt.ylabel('Y Position')
    plt.title('Time vs Y Position for Headset Data')
    plt.legend()
    plt.show()

plot('HeadsetData_GroupMeeting8-4.csv')
