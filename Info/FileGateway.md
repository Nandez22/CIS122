# File Gateway


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
> When working with types from inside of .NET (defined by Microsoft), there will generally be a method already made to do the conversion. However that is not always true for other libraries. *Just google it*
