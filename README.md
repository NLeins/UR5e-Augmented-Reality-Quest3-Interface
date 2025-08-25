# UR5e Augmented Reality Interface on Meta Quest 3
This repository contains a Unity project, which teaches the control and programming of a UR5e from Universal Robots. The app was developed for Meta Quest 3 and communicates with the robots via ROS2.

YouTube: (https://youtu.be/r3x62d7LTLU)

Unity-Version: 2022.3.50f (URP)

## ROS2 Setup
ROS2 needs to run the [Universal Robots driver](https://github.com/UniversalRobots/Universal_Robots_ROS2_Driver) and [ROS TCP Endpoint package](https://github.com/Unity-Technologies/ROS-TCP-Endpoint) to establish the connection between the robot and the Quest 3 application. If ROS2 is correctly set up and connected to the robot operating in external control mode, the AR application automatically connects after starting it.

## Features
<img width="309" height="211" alt="Waypoint Visualization" src="https://github.com/user-attachments/assets/697da7b5-d7de-462e-add4-56781884e9a4" />
<img width="183" height="240" alt="Coordinate System Visualiziation" src="https://github.com/user-attachments/assets/0af95283-0380-4f40-b8ff-ed7cde80d07c" />
<img width="384" height="211" alt="Augmented Reality UI" src="https://github.com/user-attachments/assets/b3bb8913-ce0f-465b-9b05-5b6d6e808dfa" />

## Setting the spatial anchor for the robot position
To determine the position of the real robot in three-dimensional space, the base must be manually set once with a persistent spatial anchor. To do this, use the right controller of the Quest 3.

1. Press the joystick on the right controller.
2. Grab the coordinate system that appears with the controller using the middle finger button and drag it to the robot base.
3. Confirm the position using the index finger button.

Then, virtual visualizations align with the real robot. If the position is not accurate, repeat the process.
