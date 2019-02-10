# Exceptions

If you write software for a living in 2019 or later, it’s likely that you’re at the very least familiar with the concept of exceptions.

## What is an exception?
An exception is a mechanism you can use to deal with errors. It’s that simple. In certain scenarios where, let’s say, a C programmer would return an error code, a Java or C# programmer would most likely throw an exception.

An exception represents an abrupt interruption of the execution flow. As soon as an exception is thrown, the execution stops. If the exception goes unhandled, the application crashes.

## Common exceptions

When writing code a developer should be
- Aware of these exceptions.
- Learn how to assert for issues when possible.
- Use [try/catch](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/try-catch) statements when appropriate.
- When a lightbulb appears in the IDE code gutter pay attention, either [Visual Studio](https://visualstudio.microsoft.com/) or [ReSharper](https://www.jetbrains.com/resharper/) [analyzers](https://github.com/dotnet/roslyn-analyzers) may be alerting you to a potential issue.
- Consider using the base class BaseExceptionProperties from [NuGet package](https://www.nuget.org/packages/BaseConnectionLibrary/#).
- Write [unit test](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics?view=vs-2017) often.

| Exception Class  | Cause of Exception |
| ------------- | ------------- |
| SystemException  | A failed run time check; used as a base class for other exceptions .  |
| AccessException  | Failure to access a type member , such as a method or field.  |
| ArgumentException  | An argument to a method was invalid.  |
| ArgumentNullException  | A null argument was passed to a method that does not accept it.  |
| ArgumentOutOfRangeException  | Argument value is out of range.  |
| ArithmeticException  | Arithmetic over or underflow has occurred.  |
| ArrayTypeMismatchException  | Attempt to store the wrong type of object in an array.  |
| BadImageFormatException  | Image is in wrong format  |
| CoreException  | Base class for exceptions thrown by the runtime.  |
| DevideByZeroException  | An attempt was made to divide by Zero.  |
| FormatException  | The format of an argument is wrong.  |
| IndexOutofRangeException  | An Array index is out of range  |
| InvalidCastException  | An attempt was made to cast to an invalid class.  |
| InvalidOperationException  | A method was called at an invalid time  |
| MissingmemberException  | An invalid version of a DLL was accessed  |
| NotFiniteException  | A number is not valid  |
| NotSupportedException  | Indicates that a method is not implemented by a class  |
| NullReferenceException  | Attempt to use an unassigned reference  |
| OutofmemoryException  | Not enough memory to continue execution  |
| StackOverFlowException  | A Stack has overflowed  |
