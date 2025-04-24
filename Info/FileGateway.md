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

##Parsing Files
Parsing files is a super deep topic that you should do some research into, but for now we are going to focus on one method that is specific to reading info from a `.csv` file.

As some food for thought, before I just show the answer, consider the following information and think of how you could use it to solve the problem:
> [!NOTE]
> For this problem we are going to be using the ReadAllLines() method. (see [documentation](www.google.com)
