# Rover

This program runs a rover simulation where you can continuously send the rover commands as a string
(such as "FFRFF") and the rover will move on a given grid. 

Commands are F = forward, B = backward, L = turn left, R = turn right.

## Implementation

The project uses .Net 5 and extensions, such as Extensions.Hosting for dependency injection.

You can build and run and type commands in, one command string per line and press enter.
When done, you can stop the simulation with Ctrl+C.

## Tests

There are tests in the test folder. You can run them to check that everything works as expected,
if you want to do changes on the code.
