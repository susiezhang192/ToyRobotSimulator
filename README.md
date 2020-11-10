This is a console application using netcore 3.1. It uses a txt file to store all the commands. The commands must be writen in the following format: <br>
PLACE 1,2,EAST <br>
MOVE <br>
MOVE <br>
LEFT <br>
MOVE <br>
REPORT

To start the application, go to the ToyRobotSimulator project folder, run commands: <br>
dotnet run txtfilefullpath <br>
For example: dotnet run "C:\Repos\ToyRobotSimulator\ToyRobotSimulator\test.txt"

This solution also includes a unit test project, which is using MSTest V2.1.
