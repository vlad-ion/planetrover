# Rover

This program runs a rover simulation where you can continuously send the rover commands as a string
(such as "FFRFF") and the rover will move on a given grid map.

The map wraps around at the edges and hopefully the projection used to create it maintains equal
distances so that the rover travels similar distances at the equator and at the poles. So when
the rover goes off the map on the right edge it moves to the left edge on the same row, same for
top and bottom edges.

Commands are F = forward, B = backward, L = turn left, R = turn right.

The 

## Usage

You can build and run the project,then type commands in, one command string per line and press enter.
Rover starts at position 0,0 heading North on a 100x100 grid map by default.
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

The project uses .Net 5 and extensions, such as Extensions.Hosting for dependency injection.

## Tests

There are tests in the test folder. You can run them to check that everything works as expected,
if you want to do changes on the code.
