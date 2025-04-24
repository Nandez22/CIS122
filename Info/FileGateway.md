> [!IMPORTANT]
> In this repo there is a [FULL CS SOLUTION](../Examples/FileGateway/FileGateway) that you can download, check out and run complete with test data. </br>
> I HIGHLY encourage you to give it a look. (You can download it [HERE](https://github.com/Nandez22/CIS122/releases/download/FileGatewayExample/FileGateway.zip) aswell)

# File Gateway
## Intro
Filegateway is one of the fist problems that you are given (besides the Unity project) where you have to think about a handful of different steps and consider logic, data and IO at once.
Because of that it can be overwhelming, but I promise it's pretty simple. I know the length of this writeup doesn't make it look that way, but I wanted to make sure that I covered every component of the problem.
As mentioned in the note above there is an actual CS project that you can download and view / test in full that won't look as intimidating. I recommend that you read through this, then go download the project.
Of course if I missed a detail or you have further questions feel free to reach out!

## Problem
The problem "prompt" is: "Given a `.csv` filepath and format, parse the data into 'Album' objects that can be placed into a list and operated on by code (in this case printed out)".</br>
For the problem you will be given the path to a csv file, as well as some description of the data it's holding. 

In this instance we have a csv with the columns `Title`, `Artist`, `ReleaseDate`, `Duration` and `NumSongs`.
As mentioned we are working with Albums. 

So knowing this we need to:
* Create a class based off the csv structure
* Create a method that gets data from the csv and converts it into a list of objects
* Create a program that uses the method and file path to get and print out a list of these objects

This seems like a lot so we will try and focus on each step and the decisions we need to make before going deep into the code.

## Data
We will begin with a sample of data, only a few entries so it doesn't look too intimidating:
<table>
  <caption><b>Albums</b></caption>
  <tr>
    <th>Title</th>
    <th>Artist</th>
    <th>Release Date</th>
    <th>Duration</th>
    <th>Song Count</th>
  </tr>
  <tr>
    <td>Utopia</td>
    <td>Travis Scott</td>
    <td>2023-07-28</td>
    <td>73.0</td>
    <td>19</td>
  </tr>
  <tr>
    <td>ZABA</td>
    <td>Glass Animals</td>
    <td>2014-06-06</td>
    <td>44.22</td>
    <td>11</td>
  </tr>
  <tr>
    <td>To Pimp a Butterfly</td>
    <td>Kendrick Lamar</td>
    <td>2015-03-15</td>
    <td>78.51</td>
    <td>16</td>
  </tr>
</table>

Just looking at this we have a clear, well defined class structure.
Clearly this table holds albums, where each row is one album and each column represents one of the albums attributes.
If we were to mimick this with a class it would probably look something like this:

```cs
public class Album {
    public string Title;
    public string Artist;
    public DateOnly ReleaseDate;
    public double Duration;
    public int NumSongs;
}
```
Of course we still need to add our gets, sets, constructors and so on; however I think it's more important to think about the generic structure of what we are making rather than each of those specifics (for now).
Going back to the problem description, we need to parse the csv file (of the above format) into a list of objects. Now we know what those objects are, so we can move on the the other parts of this problem.
## Parsing Files
### Reading Files
Parsing files is a super deep topic that you should do some research into, but for now we are going to focus on one method that is specific to reading info from a `.csv` file.

As some food for thought, before I just show the answer, consider the following information and think of how you could use it to solve the problem:
> [!NOTE]
> For this problem we are going to be using the ReadAllLines() method. *(see [documentation](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.readalllines?view=net-9.0))*</br>
> The method returns an array of strings (`string[]`), were each string is a line from the file. In the case of a `.csv` file, each line is a row from the table.</br>
> So if we were to run said method on a csv based on the above table, it would return an array where the last entry would be:</br>
> `"To Pimp a Butterfly,Kendrick Lamar,2015-03-15,78.51,16"`.</br></br>
> So in essence, each album is an element from the returned array.

I also want to note that the method is called using `File.ReadAllLines()`, `File` here is not referring to the file we are trying to open. `File` is a static system class just like the `Math` or `Convert` classes.
The only reference we need to have to the file we want to open is it's path. Say we were to call the file's path `filePath`; We would then call `File.ReadAllLines(filePath)` to get the rows from our csv located at `filePath`.

In practice our code would look something like this:
```cs
public static List<Album> ParseCSV(string filepath) {
    string[] rows = File.ReadAllLines(filepath);
}
```
Now we have an array that holds a string of data for every Album in the csv.</br>
Remember, each album is currently in the format `"Title, Artist, ReleaseDate, Duration, NumSongs"`. This is a good start but since it is all held in one string it is not that useful;  yet. 

### Getting Usable Data
To make use of it we need to break apart the string into the bits we care about. Looking at the string we can see that it each entry is seperated by a comma.</br>
Luckily as you may know, there is a convienent method that can -> <ins>**'Split'**</ins> <- apart this string at specific characters.</br>
If you are extremely intelligent, and what most people would consider 'gifted' you would know this method is called `.Split()`.

Given a string of items seperated a common character, say `,`: `.Split()` will return an array of strings where each element in the array is one chunk of the string seperated by `,`'s.
So, if we did something like:
```cs
string tpab = "To Pimp a Butterfly,Kendrick Lamar,2015-03-15,78.51,16";
string[] properties = tpab.Split(',');

foreach(string s in properties){
  Console.WriteLine(s);
}
```

we would get an output that looks like:
```
To Pimp a Butterfly
Kendrick Lamar
2015-03-15
78.51
16
```

So now we have an array containing all of the information we need to create an Album object.</br>
There is just one caveat we need to worry about. If we simpliy tried to do:
```cs
new Album(properties[0], properties[1], properties[2], properties[3], properties[4]);
```
We would get some errors, that's because we are still working with strings, so while `Title` and `Artist` would be just fine, we still need to worry about converting the other strings into the correct data types.

## Converting To Correct Types
This step of parsing varries quite a bit depening on what data types you are processing, and the use of more complicated data types (like storing objects) is were either json and or other databaing solutions generally shine.</br>
Fortunatly for us we don't have to worry about that right now. Looking back at our class we made the decision that `Title` and `Artist` would be `string`s, `ReleaseDate` would be a `DateOnly`, and that `Duration` and `NumSongs` would be `double`s and `int`s respectivly.
As mentioned before since `Title` and `Artist` are already strings, we don't have to worry about converting them.
For the others we need to find the proper conversion, parse or cast for each.

> [!TIP]
> Generally speaking the static `Convert` class will have conversions for most primitive types, while many objects like `DateTime` or `IPAddress` will have their own parse methods (some static some not)</br>
> When working with types from inside of .NET (defined by Microsoft), there will generally be a method already made to do the conversion. However that is not always true for other libraries. *`When in doubt google it`*

* Starting off with `ReleaseDate`, we want to convert a `string` into a `DateOnly`. Looking at the `Convert` class, you'll see a conversion for `DateTime`, but that's not what we want. Instead we will do `DateOnly.Parse()`.
* For `Duration` we need to convert a `string` into a `double`. If you were looking through the `Convert` class (or read the wonderful tip I gave), you may have seen a nice method `Convert.ToDouble()`.
* Finally for `NumSongs` we are going from `string` to `int`. Same as before using the `Convert` class, except this time there are options (scary). You will probably see `ToInt16`, `ToInt32` and `ToInt64`. These are all different data types, `short`, `int` and `long` respectivly. The difference being how large (or small) of an integer they can store (The numbers `16`, `32`, `64` refer to how many bits they take up in memory). The actual specifics of that are better left for CIS224 but it is good to be aware. Since we are converting to an `int` and ints are 32 bits, we want to use `ToInt32`.

So we want a new Album object where:
```cs
album.Title = properties[0];
album.Artist = properties[1];
album.ReleaseDate = DateOnly.Parse(properties[2]);
album.Duration = Convert.ToDouble(properties[3]);
album.NumSongs = Covert.ToInt32(properties[4]);
```

## Putting It Together
So far I have been a bit ambigous about the actual code part of the problem. The purpose was to break the problem down in a way were we could leave out some of the schemantics concerning *how* the solution is coded before actually doing so.
Now that we have done that we can actually focus on the coding part.

The first component being the Album class.
As mentioned earlier out class lacked many of the standards we are acustom to, so lets add those back in:
```cs
public class Album {
    public string Title { get; set; }
    public string Artist { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public double Duration { get; set; }
    public int NumSongs { get; set; }
    
    public Album() : this("N/A", "N/A", DateOnly.MinValue, -1, -1){}

    public Album(string title, string artist, DateOnly releaseDate, double duration, int numSongs) {
        Title = title;
        Artist = artist;
        ReleaseDate = releaseDate;
        Duration = duration;
        NumSongs = numSongs;
    }

    public override string ToString() {
        return $"{Title}\nBy: {Artist}\nReleased: {ReleaseDate}\nDuration: {Duration}\nSongs: {NumSongs}\n\n";
    }
}
```
Class structure has been well covered at this point in the class, so I won't really elaborate on any of the code here.
However now that we have a full picture of what out class actually looks like, we can elaborate on converting a csv into Album objects.

Let's start back with the code we started earlier:
```cs
public static List<Album> ParseCSV(string filepath) {
    string[] rows = File.ReadAllLines(filepath);
}
```

Now we need to expand, firstly lets look at what we need to do:
- [x] Take in a csv
- [x] Get a list of all the rows
- [ ] Break each row into Album properties
- [ ] Convert strings to expected types
- [ ] Create new `Album` object and add it to output list

Going down the list:

### Break Each Row Into Album Properties
Luckily we already went over this, yes it was only for one row but we can easily make it work for multiple:

```cs
public static List<Album> ParseCSV(string filepath) {
    string[] rows = File.ReadAllLines(filepath);
    string[] album;

    for(int i = 1; i < rows.Length; i++) {
        album = rows[i].Split(',');
    }
}
```
- [x] Break each row into Album properties

We need to put our split function into a loop because we need to create an album object out of *each* row in the csv.</br>
The reason I added `album` outside of the loop is mostly personal preference.</br>
*Technically* it is a small optimization, but again that is not a today topic, just know it can be done either way and the way you choose won't help or hurt your solution.

### Convert Strings To Expected Types 
Now we have `album` which is a string array that holds each property of one `Album` in our csv. (all of the columns of one row)
As we went over already, we need to parse this information into usable datatypes, however this time we have a proper constructor so we can do something that looks a little different:

```cs
DateOnly releaseDate = DateOnly.Parse(album[2]);
double duration = Convert.ToDouble(album[3]);
int numSongs = Convert.ToInt32(album[4]);
new Album(album[0], album[1], releaseDate, duration, numSongs);
```
- [x] Convert strings to expected types

### Create And Add New Album To Output List
Implementing this into our code is really simple, but I will be making a few changes. (Again these are out of personal preference):
```cs
public static List<Album> ParseCSV(string filepath) {
     List<Album> albums = new();
     string[] rows = File.ReadAllLines(filepath);
     string[] album;

     DateOnly releaseDate;
     double duration;
     int numSongs;

     for(int i = 1; i < rows.Length; i++) {
         album = rows[i].Split(',');

         releaseDate = DateOnly.Parse(album[2]);
         duration = Convert.ToDouble(album[3]);
         numSongs = Convert.ToInt32(album[4]);
         albums.Add(new Album(album[0], album[1], releaseDate, duration, numSongs));
     }

     return albums;
 }
```
- [x] Create new `Album` object and add it to output list
You will also notice that I have added the new `Album` object to a list. Remember we need to 

## Full Method
```cs
public class AlbumParser {
    public static List<Album> ParseCSV(string filepath) {
        List<Album> albums = new();
        string[] rows = File.ReadAllLines(filepath);
        string[] album;

        DateOnly releaseDate;
        double duration;
        int numSongs;


        for(int i = 1; i < rows.Length; i++) {
            album = rows[i].Split(',');

            releaseDate = DateOnly.Parse(album[2]);
            duration = Convert.ToDouble(album[3]);
            numSongs = Convert.ToInt32(album[4]);
            albums.Add(new Album(album[0], album[1], releaseDate, duration, numSongs));
        }

        return albums;
    }
}
```

## Running it in Main
Now that we have a proper method to parse the csv into `Album` objects, we can call it in our program.
`filePath` will be unique to your use case, and will likely result in you doing some troubleshooting.

```cs
public static void Main(string[] args) {
    string filePath = "somewhereonyourcomputer";

    List<Album> albums = AlbumParser.ParseCSV(filePath);
    foreach(Album a in albums) {
        Console.WriteLine(a);
    }
}
```

## Final Notes
You may notice that if you attempt to use test data with commas, IE: 
* `IGOR,"Tyler, The Creator",2019-05-17,39.49,12`
* `Good Kid, M.A.A.D City,Kendrick Lamar,2012-10-22,68.32,12`
You are going to get errors because the commas in `Good kid, M.A.A.D City` and `Tyler, The Creator` will cause the `.Split()` method to splite the string earlier than expected.
There are ways to get around this which I encourage you to reasearch, but I just wanted to point out that systems like this are rarley full proof. 

> [!IMPORTANT]
> In this repo there is a [FULL CS SOLUTION](../Examples/FileGateway/FileGateway) that you can download, check out and run complete with test data. </br>
> I HIGHLY encourage you to give it a look. (You can download it [HERE](https://github.com/Nandez22/CIS122/releases/download/FileGatewayExample/FileGateway.zip) aswell)

* If you get an error that the csv is not found, you will need to right click on it, select `properties` and set `Build Action` to `Content` and `Copy to Output Directory` to `Copy if newer` or `Copy Always`.
