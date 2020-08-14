## Declaration Order
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
