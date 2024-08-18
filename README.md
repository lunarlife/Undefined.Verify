
## Example:


```csharp
    public const int ARGUMENT_VALUE = 10;

    public void ExampleArgument(IReadOnlyList<int>? list)
    {
        Verify.NotNull(list); //List is not null
        Verify.Argument(list!.Contains(ARGUMENT_VALUE), "Nope"); //List contains our value
        //something...
    }
```
### There are some results of using it:
```csharp
    ExampleArgument(null); //NullReferenceException
    ExampleArgument([1, 5, -28]); //ArgumentNotPassedException
    ExampleArgument([-5, 0, 24, ARGUMENT_VALUE]); //OK
```
### Also, many auxiliary methods:
```csharp
    public const string EQUALS_VALUE = "Hello!";

    public void ExampleRange(double value)
    {
        Verify.Range(value, 1.5, 3);
        //something...
    }
    public void ExampleEquals(string other)
    {
        //Next 2 lines are the same
        Verify.Equals(other, EQUALS_VALUE, "You are not friendly :(");
        other.VerifyEquals(EQUALS_VALUE, "I was offended");
        //again something...
    }  
    public string ExampleArray(string[] array, int i)
    {
        //Check if the index is not out of an array length
        array.VerifyArray(i);
        return array[i];
    }
```
