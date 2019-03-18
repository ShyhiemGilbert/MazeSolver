# MazeSolver
This program will solve a simple .txt file maze that follows the guidelines shown in the Maze Input and Output keys.

When the program is run a file selector box will prompt a maze .txt file selection.
Once the maze has been selected the program will solve the maze showing the shortest path possible.


Maze Input Key:
<WIDTH> <HEIGHT><CR><br>
<START_X> <START_Y><CR>	(x,y) Location of the start. (0,0) Is upper left and (width-1,height-1) is lower right<br>
<END_X> <END_Y><CR>		    (x,y) Location of the end<br>
<HEIGHT.> Rows where each row has <WIDTH> {0,1} integers space delimited

Maze Output Key:
Walls marked by ='#', <br>
Passages marked by ' ',<br>
Path marked by 'X', <br>
Start/End marked by 'S'/'E'
