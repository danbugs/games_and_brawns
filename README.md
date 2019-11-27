# games_and_brawns

A game created with Unity3D that, with electromyography readings (obtained through a BITalino), helps people in muscle movement rehabilitation.

## hardware requirements

- bitalino board
![bitalino](/assets/bitalino.jpg)
  - with battery.

- bluetooth dongle
![bluetooth dongle](/assets/bluetooth%20dongle.jpg)  

- emg module
![emg_module](/assets/emg_module.jpg)

- 3-lead electrode cable
![3-lead-electrode-cable](/assets/3-lead-electrode-cable.jpg)

- 3 electrodes (+ve, -ve, gnd)
![electrodes](/assets/electrodes.jpg)

- pushbutton
![bitalino-pushbutton-btn](/assets/bitalino-pushbutton-btn.jpg)

- plux cable for pushbutton
![sensor-cable](/assets/sensor-cable.jpg)

## software requirements

- OpenSignals (r)evolution: https://bitalino.com/en/software

- git:
https://git-scm.com/downloads

- MacOS
  - tested on MacOS Mojave 10.14.5

- Games and Brawns:
```
git clone -b app https://github.com/danbugs/games_and_brawns
```

## how to play

- start the game.
- first, you will see the "visualization round", that means that there are no obstacles and you can't lose even if you hit them.
- next, you will see the "game round", that means that there are obstacles and if you hit them you lose them game.
- there's a pre-recorded run with a victory pre-loaded into the app, which is what you'll see.
- now, after the game round, you should see this screen:

![Screen Shot 2019-11-21 at 11.25.01 AM](/assets/Screen%20Shot%202019-11-21%20at%2011.25.01%20AM.png)

- connect all the hardware/wiring and electrodes to your body (+ve and -ve (black and red) in the belly of the muscle and gnd to a bone).
- start up open signals, and configure it to read emg data on port a1. Turn off all other channels. Set it to start on trigger (i.e. pushbutton) that will be connected to port i1.
- put the game screen side-by-side with open signals.
- press the pushbutton and "try again" at the same time to start playing.
- flex your muscle of choice to avoid obstacles.
- right click the game app, click "show package contents", navigate to the streamingassets folder (contents -> resources -> data -> streamingassets).
- replace your the txt file there with your data. Your file **must** be named "data_converted.txt".
- click "try again" and you should see your own run.
