
# DuneTuner - DYI light tree

This was one of my favorite projects even though I can't call it a success. The code was "good enough" but the hardware side lacked stability for it to be useful. It operated like any light tree but with sizes specific to drag racing ATVs on the sand. The light tree used LED flashlights fed by 5 volts from the Phidgets 8/8/8 controller. The sensors were Phidgets light sensors which tripped when a laser was interupted. The power was fed on one side of the run using cat5 cable to all the lasers and the sensors were fed power and sent signal back to the controller along the other side of the run. There was a set of launch sensors, a set to capture 60 foot times and another set for 300 foot times. The code itself is very very simple. The only thing not contained in the project is a database with a table for storing the run data. Although the table structure is easy enough to infer from the INSERTs and SELECTs in the code. Something like this:

`
INSERT INTO DT_Runs (stage1Time, stage2Time, sixtyFootTime, EndTimeStart, EndTimeEnd, Name, Notes, FinalReactionTime, FinalSixtyFootTime, FinalEndTime, FinalMPH)
`

## Screenshots

This is what I tried to show in the videos below. You can adjust sensitivity of each sensor, test the light tree and sensros, stop/save/reset the run by name with notes, select previous runs saved in the database to view in the chart, and see a live read out as the sensors are tripped during the run.
![Main Form](/mainform.PNG)

This is the super simple sensor form used to test laser alignment of the whole track. Aligning took a second person where we used our phones to direct the positioning of the lasers and sensors until a steady beam was achieved. The sensors provide 0 to 999, the number correlating to the maount of light was illuminating the sensor. As the front tire from the bike interupted the beam the value would fall. After adjusting the threshold I was able to determine a consistent point where the bike was reaching the stage of the track. While the precision wasn't good enough for an absolute measurement, it was certainly good enough for a relative one that provided feedback on race technique and bike operation.
![Sensor Config Form](/sensorconfig.PNG)

## Videos (circa July 2009)

I've dug into the cobwebs of the past to find some old smart phone videos I captured the first and only time this was setup. Each is very short and absent of the production quality you find on YouTube today. Fortunately they are about a minute or less, and arguably contain little helpful information. Still, its proof this was actually used at one point.

This first video is a very brief overview of the system.
[![006 overview](https://img.youtube.com/vi/WmsJRQnDLLc/0.jpg)](https://www.youtube.com/watch?v=WmsJRQnDLLc)

This short video shows the sensor config form. You can see the jitter from the sensors in part due to the wind pushing the lasers off the optimal target of the sensor on the other side of the track.
[![007 sensors](https://img.youtube.com/vi/Ha2IwATGzFo/0.jpg)](https://www.youtube.com/watch?v=Ha2IwATGzFo)

Warm up of the bike and my attempt at trying to pretend a 2009 smart phone had enough pixels to make a decent video.
[![008 pre first run](https://img.youtube.com/vi/fH8IzMpRkvI/0.jpg)](https://www.youtube.com/watch?v=fH8IzMpRkvI)

The first run produced a type casting exception, which I found odd considering everything worked at home with no issues during testing.
[![010 first run exception](https://img.youtube.com/vi/GKWXqIxdrTc/0.jpg)](https://www.youtube.com/watch?v=GKWXqIxdrTc)

The second run caused the second type casting error. After digging into the problem in the feild I relaized it had to do with .Net 1.1 using underlying OS libraries. I had moved my code from Vista at home to a laptop running Windopws 2000 and needed to account for the difference.
[![011 second run still debuging](https://img.youtube.com/vi/yuUYOG7avys/0.jpg)](https://www.youtube.com/watch?v=yuUYOG7avys)

In this video I try again to capture the form and realize its still too pixelated, so I read off the data that's being captured.
[![013 form explanation](https://img.youtube.com/vi/MjRSHvc9Tnk/0.jpg)](https://www.youtube.com/watch?v=MjRSHvc9Tnk)

A good run of the bike, nice launch, quick reaction time and the carb was more dialied in by then. A moderate success using this light tree system to help practice take offs and tune the 250R.
[![016 just the bike](https://img.youtube.com/vi/lt818_yUrpc/0.jpg)](https://www.youtube.com/watch?v=lt818_yUrpc)

## Electrical

### Tree lights

These were retail LED flashlights that were taken apart and wired with cat5 to go ot the Phidgets 8/8/8 controller. They worked well but were not bright enough in full daylight. The 5 volts feeding each was more than the 2 AA batteries it was designed for but still not enough to make it obvious to the rider. 

I would improve this by housing them in a pipe with the inside coated in silver flake paint with another larger pipe coated in flat black on the outside of that. Something like a [DSLR camera lense hood](https://www.amazon.com/55mm-Set-Camera-Lens-Hoods/dp/B07VF139D3). This would darken the light lense when it was off and scatter a bit more when on. The light being emitted would be surrounded by a bit of black making it more obvious. 
Bike reflectors were affixted to the end of the flashlights for the desired color.

### Lasers & Sensors

[Phidgets Precision Light Sensor](https://www.phidgets.com/?tier=3&catid=8&pcid=6&prodid=99) was used with a [TTL Laser](http://blog.trossenrobotics.com/2008/05/28/ttl-controlled-laser/) for each stage. This required alligning the laser to the sensor acorss the track. Given the distance (did we set it up at 30 feet?) the beam width did a great job covering the sensor through some plumbing pipe. Each was mounted to a cinder block and that was the biggest problem in the whole system. I did not account for the amount of energy the paddles of the tires would transmit though the sand. This caused the sensors to jitter too much and I had to increase the sensitivity threshold to compensate. This alone wasn't so bad, but the vibrations would cause the cinder blocks to "walk" a little, eventually needing realignment every other run. 

A big improvment would be using a screw in mount to anchor the sensors and lasers below the top layer of the sand that vibrates. This probably would have eliminated the small amount of jitter caused from strong gusts of wind too. 

Bike relfectors were used in the sensor tubes to help scatter the laser light, all of which were red like the laser, which seemed to scatter the best of the different colors I had on hand.

## Finally

This was a fun project and I highly encourage others to try things like this. I definitley didn't start any trend nor did I cover much new ground comapred to the companies that already build things like this. But it was fairly low cost and did seem to work, even if some implementation problems kept this from being perfect. 












