### Notes

All exceptions caught in this project could had been avoided by using proper assertion.

**Example**

Correct method to determine if an object is an int.
```csharp
object o = "10";
var value = o.ToString();
if (int.TryParse(value, out var result))
{
    Console.WriteLine("o is indeed an int");
}
else
{
    Console.WriteLine("o can not be converted to int");
}
```
While this method although works should never had been wrapped in a try/catch
```csharp
try
{
    object o = "10";
    int x = (int)o;
}
catch (Exception e)
{
    mHasException = true;
    mLastException = e;
}
```