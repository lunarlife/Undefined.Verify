EXAMPLE:

```csharp
object? obj = new();
Verify.NotNull(obj); //No error
obj = null;
Verify.NotNull(obj); //Error

var array = new int[20];
Verify.RangeArray(array, 10); //No Error
Verify.RangeArray(array, 20); //Error
```