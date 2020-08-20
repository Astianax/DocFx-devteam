## Declaration Order
#
>[!NOTE]
>- Group internal class implementation by type in the following order:
>
>> 1. Nested Enums, Structs, and Classes
>>  2. Member variables
>>  3. Properties
>>  4. Constructors &amp; Finalizers
>>  5. Methods
>
>- Sequence declarations within type groups based upon access modifier and visibility:
>
>>  1. Public
>>  2. Protected
>>  3. Internal
>>  4. Private
>
>- Segregate interface Implementation by using **#region** statements

## Visibility
#
- The visibility modifier is required for all types, methods and fields; this makes the intention explicit and consistent.

- The visibility keyword is always the first modifier.

- The **const** or **readonly** keyword, if present, comes immediately after the visibility modifier.

- The **static** keyword, if present, comes after the visibility modifier and **readonly** modifier.
    
    ```csharp
    private readonly static string DefaultDatabaseName = "admin";
    ```

## Constants
#

- Declare all constants other than **0** , **1** , **true** , **false** and **null**.
- Use **true** and **false** only for assignment, never for comparison.
- Avoid passing **true** or **false** for parameters; use an **enum** or constants to impart meaning instead.
- If there is a logical connection between two constants, indicate this by making the initialization of one dependent on the other.
    
    ```csharp
    public const int DefaultCacheSize = 25;
    public const int DefaultGranularity = DefaultCacheSize / 5;
    ```

## Readonly vs Const
#
- The difference between **const** and **readonly** is that **const** is compiled and **readonly** is initialized at runtime.
- Use **const** only when the value really is constant (e.g. **NumberDaysInWeek** ); otherwise, use **readonly**.
- Though **readonly** for references only prevents writing of the reference, not the attached value, it is still a helpful hint for both the compiler and the reader.

## String and Resources
#
- **Do not** hardcode strings that will be presented to the user; use resources instead. For products in development, this text extraction can be performed after the code has crystallized somewhat.
- Resource identifiers should be alphanumeric, but may also include a dot (&quot;.&quot;) to logically nest resources. It should contain the name of the control sample &quot;lblName&quot;, &quot;lblLastName&quot;, etc.
- **Do not** use constants for strings; use resource tables instead (this aids translation, if necessary).
- Configuration data should be moved into application settings as soon as possible.


## Properties
#
- Prefer automatic properties as it saves a lot of typing and vastly improves readability.

    ```csharp
    public bool ShowTab { get; set; }
    ```
- If there a exceptional need to manage the internal value of public property then you can create private properties.
- Use read-only properties if there is no logical reason for calling code to be able to change the value.
- Properties should be commutative; that is, it should not matter in which order you set them.
- Avoid enforcing an ordering by using a method to execute code that you would want to execute from the property setter. The following example is incorrect because setting the password before setting the name causes a login failure.

    ```csharp
    class SecuritySystem
    {
        public string UserName { get; set; }

        public int Password { get; set { LogIn(); }

        protected void LogIn()
        {
              IPrincipal principal = Authenticate(UserName, Password);
        }

        private IPrincipal Authenticate(string UserName,int Password)
        {
              // Authenticate the user
        }
    }
    ```

- Instead, you should take the call LogIn() out of the setter for Password and make the method public, so the class can be used like this instead:

    ```csharp
    SecuritySystem system = new SecuritySystem();
    system.Password = "knockknock";
    system.UserName = "Encode";

    system.LogIn();
    ```

- In this case, Password can be set before the UserName without causing any problems.


## Methods / Functions
#
- Methods should not have more than 200 lines of code.
- Avoid returning null for methods that return collections or strings. Instead, return an empty collection (declare a static empty list) or an empty string (Empty).
    

**Overloads** are encouraged for methods that are in the same family and either serve the same purpose or have similar behavior. Do not use the types of parameters to distinguish these functions from one another. For example, the following is incorrect

>```csharp
>void Update();
>
>void UpdateUsingQuery(IQuery query);
>
>void UpdateUsingSql(string sql);
>```

Instead, use an overload, letting the method signature describe the different functions. This reduces the perceived size of the API and makes it easier to understand.

>```csharp
>void Update();
>
>void Update(IQuery query);
>
>void Update(string sql);
>```

## Parameters
#
- Methods should not have more than 10 parameters (consider using a **struct** instead).
- Methods should not have more than 2 out or ref parameters (consider using a **struct** instead).
- **ref** and **out** parameters should come last in the list of parameters.
- The implementation of an interface method should use the same parameter name as that given in the interface method declaration.

- **Do not** declare reserved parameters (use overloads in future library versions instead).

## Classes
#
- Never declare more than one field per line; each field should be an individually documentable entity.

- **Do not** use **public** or **protected** fields; use private fields exposed through properties instead.

- **Do not** create too many static classes; instead, determine whether new functionality can be added to an existing static class.

## Interfaces
#
- Use interfaces to &quot;fake&quot; multiple-inheritance.

- Define interfaces if there will be more than one implementation of a hierarchy; without multiple-inheritance, this is the only way to remain flexible as to the implementation.

- Define interfaces to clearly define what comprises an API; an interface will generally be smaller and more tightly-defined that the class that implements it. A class-based hierarchy runs the risk of mixing interface methods with implementation methods.

- Consider using a c attribute instead of a marker interface (an interface with no members). This makes for a cleaner inheritance representation and indicates the use of the marker better (e.g. NUnit tests as well as the serializing subsystem for .NET use attributes instead of marker interfaces).

- Re-use interfaces as much as possible to avoid having many very similar interfaces that cause confusion as to which one should be used where.

- Keep interfaces relatively small in order to ease implementation (5-10 members).

- Where possible, provide an abstract class or default descendent that application code can use for implementing an interface. This provides both an implementation example and some protection from future changes to the interface.

- Use interfaces where the functionality isn&#39;t the direct purpose of the object or to expose a part of the class&#39;s functionality (as with aspect-oriented programming).

- Use explicit interface implementation where appropriate to avoid expanding a class API unnecessarily.

- Each interface should be used at least once in non-testing code; otherwise, get rid of it.

- Always provide at least one, tested implementation of an interface.

## Structs
#
Consider defining a structure instead of a class if most of the following conditions apply:

- Instances of the type are small (16 bytes or less) and commonly short-lived.
- The type is commonly embedded in other types.
- The type logically represents a single value and is similar to a primitive type, like an **int** or a **double**.
- The type is immutable.
- The type will not be boxed frequently.

Use the following rules when defining a **struct** :

- Avoid methods; at most, have only one or two methods other than overrides and operator overloads.
- Provide parameterized constructors for initialization.
- In scenarios that require a significant amount of boxing and un-boxing, value types perform poorly as compared to     reference types.
- Overload operators and equality as expected; implement IEquatable instead of overriding **Equals** in order to avoid the  negative performance impact of boxing and un-boxing the value.
- A struct should be valid when uninitialized so that consumers can declare an instance without calling a constructor.
- Public fields are allowed (even encouraged) for structures used to communicate with external APIs through unmanaged code.

## Enumerations
#
- Always use enumerations for strongly-typed sets of values
- Use enumerations instead of lists of static constants _unless_ that list can be extended by descendent code; if the list is not logically open-ended, use an **enum**.
- Enumerations are like interfaces; be extremely careful of changing them when they are already included in code that is not under your control (e.g. used by a framework that is, in turn, used by external application code). If the enumeration must be changed, use the **ObsoleteAttribute** to mark members that are no longer in use.
- **Do not** assign a type to an **enum** unless absolutely necessary; use the default type of **Int32** whenever possible.
- **Do not** include sentinel values, such as **FirstValue** or **LastValue**.
- **Do not** assign explicit values to simple enumerations except to enforce specific values for storage in a database.
- The first value in an enumeration is the default; make sure that the most appropriate simple enumeration value is listed first.

## Local variables
#
Declare a local variable as close as possible to its first use (and within the most appropriate scope).

If a local variable is initialized, put the initialization on the same line as the declaration. If the line gets too long, use multiple lines as described before in this guide.

## Event Handlers
#
You should use the pattern and support classes for event-handling provided by the .NET library.

- Do not expose delegates as public members; instead declare events using the event keyword.
- **Do not** add a method to a delegate with new **EventHandler(…)**; instead, use delegate inference.
- **Do not** define custom delegates for event handling; instead use ```EventHandler<T>```.
- Put all extra event data into an **EventArgs** descendent; subsequent versions can alter this descendent without changing the signature.
- Use **CancelEventArgs** as the base class if you need to be able to cancel an event.
- Neither the sender parameter nor the **args** parameter may be null; this avoids forcing event handlers to check for null.
- **EventsArgs** descendents should declare only properties, not methods or other application logic.

## Operators
#
- Be extremely careful when overloading operators; in general, you should only do so for **structs**. If you feel that an operator overload is especially clever, it probably isn&#39;t; check with another developer before coding it.
- Avoid overriding the **==** operator for reference types; override the **Equals()** method instead to avoid redefining reference equality.
- If you do override **Equals()**, you should also override **GetHashCode()**.
- If you do override the **==** operator, consider overriding the other comparison operators **(=, <, <=, >, >=)** as well.
- You should return false from the **Equals()** function if the objects cannot be compared.
- However, if they are different types, you may throw an exception.



## If Statements
#
- **Do not** compare to **true** or **false** ; instead, compare pure Boolean expressions.
- Initialize Boolean values with simple expressions rather than using an if-statement; always use parentheses to delineate the assigned expression.

>```csharp
>bool needsUpdate = (Count > 0 && Objects[0].Modified);
>```
- Always use brackets for flow-control blocks (switch, if, while, for, etc.)
- **Do not** add useless else blocks. An &quot;if&quot; statement may stand alone and an &quot;else if&quot; statement may be the last condition.

>```csharp
>if (a == b)
>{
>    // Do something
>}
>else if (a > b)
>{
>    // Do something else
>}
>
>// No final "else" required
>```
- Do not force really complicated logic into an &quot;if&quot; statement; instead, use local variables to make the intent clearer. For example, imagine we have a lesson planner and want to find all unsaved lessons that are either unscheduled or are scheduled within a given time-frame. The following condition is too long and complicated to interpret quickly:

>```csharp
>if (!lesson.Stored && (((StartTime <= lesson.StartTime) && (lesson.EndTime >= EndTime)) || !lesson.Scheduled))
>{
>    // Do something with the lesson
>}
>```

- Even trying to apply the line-breaking rules results in an unreadable mess:

>```csharp
>if (!lesson.Stored && (((StartTime <= lesson.StartTime) && (lesson.EndTime >= EndTime)) || !lesson.Scheduled))
>{
>    // Do something with the lesson
>}
>```

- Even with this valiant effort, the intent of the ||-operator is difficult to discern. With local variables, however, the logic is much clearer:
    
>```csharp
>bool lessonInTimeSpan = ((StartTime <= lesson.StartTime) && (lesson.EndTime >= EndTime));
>
>if (!lesson.Stored && (lessonInTimeSpan || ! lesson.Scheduled))
>{
    >// Do something with the lesson
>}
>```

## Using &quot;var&quot;
#
The use of var is permitted ONLY when the explicit-type is **not known** or **unavailable**. The use of var can be used **only** when you need  to:

- Use the type of ObjectQuery
- Use code that changes the type at runtime instead of compiletime. Is **VERY IMPORTANT** to comment the code with the specifications of this code.

The use of var is **only allowed** when:

- The explicit-type is **not known** (anonymous).

>```csharp
>var car = new { Year = 2020, Model = "Mustang GT", Manufacturer = "Ford" };
>```

- Working with **LINQ queries.**

    ```csharp
    var query = from c in DataContext
                where c.Id = 123
                select new Car { 
                    Year = c.Year, 
                    Model = c.Model, 
                    Manufacturer = c.Model 
                };
    ```
- Initializing the variable directly with an **object constructor call**.

    ```csharp
    var car = new Car();
    ```
- Readability needs to be improved.

    ```csharp
    //Bad

    List<ThisIsMyLongCustomCarTypeObject> data = CarTypeObjectEngine.GetAvailableModelByManufacturerId(1);

    // Good
    var data = CarTypeObjectEngine.GetAvailableModelByManufacturerId(1);
    ```

**Note:** _If the developer wants to know the type inside the &quot;var&quot; just move the cursor to the variable name._

The use of var is **NOT allowed** when:

- Initializing **value types** or **string**.

    ```csharp
    var index = 0;
    var name = "John Doe";
    ```

## Flow Control
#
- Avoid invoking methods within a conditional expression.
- Avoid creating recursive methods. Use loops or nested loops instead.
- Avoid using foreachto iterate over immutable value-type collections. E.g. String arrays.
- Do not modify enumerated items within a foreach
- Use the **ternary** conditional operator only for trivial conditions. Avoid complex or compound ternary operations.
    ```csharp
    int result = isValid ? 9 : 4;
    ```
    
- Avoid evaluating Boolean conditions against truer false.
    ```csharp
    //Example:

    // Bad!
    if (isValid == true) {...}

    // Good!
    if (isValid) {...}
    ```
    
- Avoid assignment within conditional statements.
    ```csharp
    //Example:

    if((i=2) == 2) {...}
    ```
    
- Avoid compound conditional expressions – use Boolean variables to split parts into multiple manageable expressions.
    ```csharp
    //Example:

    // Bad!

    if (((value > _highScore) && (value != _highScore)) && (value < _maxScore)) {...}

    // Good!

    isHighScore = (value >= _highScore);

    isTiedHigh = (value == _highScore);

    isValid = (value < _maxValue);

    if ((isHighScore && !isTiedHigh) && isValid) {...}
    ```
    
- Avoid explicit Boolean tests in conditionals.
    ```csharp
    //Example:

    // Bad!
    if(IsValid == true) {...}

    // Good!
    if(IsValid) {...}
    ```
    
- Only use switch/casestatements for simple operations with parallel conditional logic.
- Prefer nested if/elsever switch/casefor short conditional sequences and complex conditions.
- Prefer polymorphism over switch/caseto encapsulate and delegate complex operations.


## Exceptions
#
- Do not use try/catch blocks for flow-control.
- Only catch exceptions that you can handle.
- Never declare an empty catch.
- Avoid nesting a try/catch within a catch.
- Always catch the most derived exception via exception filters.
- Order exception filters from most to least derived exception type.
- Avoid re-throwing an exception. Allow it to bubble-up instead.
- If re-throwing an exception, preserve the original call stack by omitting the exception argument from the throw

    ```csharp
    //Example:

    // Bad!

    catch(Exception ex)
    {
        Log(ex);
        throw ex;
    }

    // Good!

    catch(Exception)
    {
        Log(ex);
        throw;
    }
    ```
    
- Only use the finallyblock to release resources from a try
- Always use validation to avoid exceptions.

    ```csharp
    //Example:

    // Bad!

    try
    {
        conn.Close();
    }
    Catch(Exception ex)
    {
        // handle exception if already closed!
    }

    // Good!
    if(conn.State != ConnectionState.Closed)
    {
        conn.Close();
    }
    ```
    
- Always set the innerExceptionproperty on thrown exceptions so the exception chain &amp; call stack are maintained.
- Avoid defining custom exception classes. Use existing exception classes instead.
- When a custom exception is required;
  - Always derive from Exception **not** ApplicationException.
  - Always suffix exception class names with the word &quot;Exception&quot;.
  - Always add the SerializableAttributeto exception classes.
  - Always implement the standard &quot;Exception Constructor Pattern&quot;:

    ```csharp
    //Example:
    public MyCustomException ();

    public MyCustomException (string message);

    public MyCustomException (string message, Exception innerException);
    ```
    
  - Always implement the deserialization constructor:

    ```csharp
    protected MyCustomException(SerializationInfo info, StreamingContext contxt);
    ```
    
- Always set the appropriate HResultvalue on custom exception classes.

    ( **Note:** the ApplicationExceptionHResult = -2146232832)

- When defining custom exception classes that contain additional properties:
  - Always override the Messageproperty, ToString()method and the implicit operator string to include custom property values.
  - Always modify the deserialization constructor to retrieve custom property values.
  - Always override the GetObjectData(…)method to add custom properties to the serialization collection.
    
    ```csharp
    //Example:

    public override void GetObjectData(SerializationInfo info,

    StreamingContext context)
    {
        base.GetObjectData (info, context);
        info.AddValue("MyValue", _myValue);
    }
    ```