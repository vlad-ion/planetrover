# Rover

This program runs a rover simulation where you can continuously send the rover commands as a string
(such as "FFRFF") and the rover will move on a given grid map.

The map wraps around at the edges and hopefully the projection used to create it maintains equal
distances so that the rover travels similar distances at the equator and at the poles. So when
the rover goes off the map on the right edge it moves to the left edge on the same row, same for
top and bottom edges.

Commands are F = forward, B = backward, L = turn left, R = turn right.

## Usage

You can build and run the project, then type commands in, one command string per line and press enter.
Rover starts at position 0,0 heading North on a 100x100 grid map by default. The default map can be
changed from the appsettings.json file.

When done, you can stop the simulation with Ctrl+C.

Example:

FFRFF

(press enter)

(rover moves and lists new position)

BLBL

(press enter)

(rover moves and lists new position)

...


## Implementation

The project uses .Net 5 and extensions, such as ILogger or Extensions.Hosting for dependency injection.

A basic json configuration was implemented in appsettings.json and it can be easily extended to send
IOptions to the various components if needed (such as setting various values that are consts now).
For now only DI initialization values were needed.

It's pretty simple to change the project to be a webservice, by changing Program.cs and adding routing
to RoverController.cs

The implementation is flexible enough to allow adding several rovers with different behaviors, more
commands, custom maps or extend to draw the map and the current rover position.

## Tests

There are tests in the test folder. You can run them to check that everything works as expected,
if you want to do changes to the code.
