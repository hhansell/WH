# William Hill Technical Test

Console implementation of the William Hill technical test. 

This program takes two command line arguments which contain the paths to the two CSV files containing settled and 
unsettled bet data as per the speicification.

Once the data has been loaded the program will run a set of pre-defined risk scenarios and output the resultant information
to the console.

## Usage

The program can be run by invoking the executable with the two command line arguments: 

WilliamHill.TechChallenge.exe "<settled bets csv path>" "<unsettled bets csv path>"

Additional config settings to control the risk scenarios can be found in the WilliamHill.TechChallenge.exe.config file

