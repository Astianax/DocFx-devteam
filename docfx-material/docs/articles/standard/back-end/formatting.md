## Indent and spacing

- An indent is four (4) spaces.
- Use a single space after a comma (e.g. between function arguments).
- There is no space after the leading parenthesis/bracket or before the closing parenthesis/bracket.
- There is no space between a method name and the leading parenthesis, but there is a space before the leading parenthesis of a flow control statement.
- Use a single space to surround all 2 infix operators (e.g. firstValue ?? secondvalue : thirdValue); there is no space between a prefix operator (e.g. &quot;-&quot; or &quot;!&quot;) and its argument.
- Do not use spacing to align type members on the same column (e.g. as with the members of an enumerated type).

## Braces

- Curly braces should—with a few exceptions outlined below—go on their own line.
- A line with only a closing brace should never be preceded by an empty line.
- A line with only an opening brace should never be followed by an empty line.

## Return Statements

- If a return statement is not the only statement in a method, it should be separated from other code by a single newline (or a line with only a bracket on it).

>>```csharp
>>if (a == 1)
>>{
  >>return true;
>>}
>>
>>return false;
>>```
>>[!CAUTION]
>> ```csharp
>>if (a == 1)
>>
>>{
>>
 >> return true;
>>}
>>//**Do not** use else with return statements (use the style shown above instead):
>>else// Not necessary
>>
>>{
>>
  >>return false;
>>
>>}
## Switch Statements

- Contents under switch statements should be indented.
- Braces for a case-label are not indented; this maintains a nice alignment with the brackets from the switch-statement.
- Use braces for longer code blocks under case-labels; leave a blank line above the break statement to improve clarity.
```csharp
switch (flavor)

{

  case Flavor.Up:

  case Flavor.Down:

  {

    if (someConditionHolds)

    {

      // Do some work

    }

    // Do some more work

    break;

  }

  default:

    break;

}
```

## Empty Lines

In the following list, the phrase &quot;surrounding code&quot; refers to a line consisting of more than just an opening or closing brace. That is, no new line is required when an element is at the beginning or end of a methods or other block-level element.

Always place an empty line in the following places:

- Between the file header and the namespace declaration or the first using statement.
- Between the last using statement and the namespace declaration.
- Between types (classes, structs, interfaces, delegates or enums).
- Between public, protected and internal members.
- Between a call to a base method and ensuing code.
- Between return statements and surrounding code (this does not apply to return statements at the beginning or end of methods).
- Between block constructs (e.g. while loops or switch statements) and surrounding code.
- Between documented enum values; undocumented may be grouped together.
- Between logical groups of code in a method; this notion is subjective and more a matter of style. You should use empty lines to improve readability, but should not overuse them.
- Between the last line of code in a block and a comment for the next block of code.
- Between statements that are broken up into multiple lines.
- Between a #region tag and the first line of code in that region.
- Between the last line of code in a region and the #endregion tag.

>[!CAUTION]
>**Do not** place an empty line in the following places:
>
>- After another empty line; the AFCG style uses only single empty lines.
>- Between retrieval code and handling for that code. Instead, they should be formatted together.
>```csharp
>IMetaReadableObject obj = context.Find\&lt;IMetaReadableObject\&gt;();
>
>if (obj == null)
>
>{
>
>context.Recorder.Log(Level.Fatal, String.Format(&quot;Error!&quot;));
>
>return null;
>
>}
>```
>- Between any line and a line that has only an opening or closing brace on it (i.e. there should be no leading or trailing newlines in a block).
>- Between undocumented fields (usually private); if there are many such fields, you may use empty lines to group them by purpose.

## Line Breaking
>[!CAUTION]
>**Do not** put more than one statement on a single line because it makes stepping through the code in a debugger much more difficult.
>
>- No line should exceed 100 characters; use the line-breaking rules listed below to break up a line.
>- Use line-breaking only when necessary; do not adopt it as standard practice.
>- If one or more line-breaks is required, use as few as possible.
>- Line-breaking should occur at natural boundaries; the most common such boundary is between parameters in a method call or definition.
>- Lines after such a line-break at such a boundary should be indented.
>- The separator (e.g. a comma) between elements formatted onto multiple lines goes on the same line after the element; the IDE is much more helpful when formatting that way.
>- The most natural line-breaking boundary is often before and after a list of elements. For example, the following method call has line-breaks at the beginning and end of the parameter list.
>
>```csharp
>people.DataSource = CurrentCompany.Employees.GetList(
>
>connection, metaClass, GetFilter(), null
>
>);
>```
>- If one of the parameters is much longer, then you add line-breaking between the parameters; in that case, all parameters are formatted onto their own lines:
>```csharp people.DataSource = CurrentCompany.Employees.GetList(
>
>connection,
>
>metaClass,
>
>GetFilter(&quot;Global.Applications.Updater.PersonList.Search&quot;),
>
>null
>
>);
>```
>
>
>
>**Note** in the examples above that the parameters are indented. If the assignment or method call was longer, they would no longer fit on the same line. In that case, you should use two levels of indenting.
>
>- Avoid nesting more than two ternary operators in a single line. Break it down into a series of if/else statements.
>```Csharp
>// Bad!
>
>bool result = condition1 ? true : contition2 ? true : condition3 ? true : false;
>
>// Good!
>
>if(condition1)
>
>      {
>
>          result = true;
>
>      }
>
>       elseif(condition2)
>
>       {
>
>           result = true;
>
>       }
>
>       elseif(condition3)
>
>       {
>
>           result = true;
>
>       }
>
>       else
>
>       {
>
>           result = false;
>
>}
>```

## Code Commenting

- All comments should be written in the same language, be grammatically correct, and contain appropriate punctuation.
-  Use // or /// but never /\* … \*/
-   **Do not** &quot;flowerbox&quot; comment blocks.

// \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

// Comment block

// \*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*\*

- Use inline-comments to explain assumptions, known issues, and algorithm insights.
- In-line comments are the Post-It notes of programming. This is where you make annotations to help yourself or another programmer who needs to work with the code later. Use In-line comments to make notes in your code about:
  - _What you are doing._
  - _Where you are up to._
  - _Why you have chosen a particular option._
  - _Any external factors that need to be known._
- Here are some examples of appropriate uses of In-line comments:
- What we are doing:

// Now update the control totals file to keep everything in sync

- Where we are up to:

// At this point, everything has been validated.

// If anything was invalid, we would have exited the procedure.

- Why we chose a particular option:

// Use a sequential search for now because it&#39;s simple to code

// We can replace with a binary search later if it&#39;s not fast

// enough

// We are using a file-based approach rather than doing it all

// in memory because testing showed that the latter approach

// used too many resources under Win2000. That&#39;s why the code

// is here rather than in XXX.VB where it belongs.

- External factors that need to be kept in mind:

// This assumes that the INI file settings have been checked by

// the calling routine

- **Do not** use inline-comments to explain obvious code. Well written code is self-documenting.
- Notice that we are **not** documenting what is self-evident from the code. Here are some examples of **inappropriate** In-line comments:

// Declare local variables

int currentEmployee;

// Increment the array index

currentEmployee += 1;

// Call the update routine

UpdateRecord();

- Include comments using Task-List keyword flags to allow comment-filtering.

// TODO: Place Database Code Here

// TODO: Removed P\Invoke Call due to errors

- Always apply c comment-blocks (///) to public, protected, and internal
- Only use c comment-blocks for documenting the API.
- Always include \&lt;summary\&gt; Include \&lt;param\&gt;, \&lt;return\&gt;, and  \&lt;exception\&gt;comment sections where applicable.
- Include \&lt;see cref=&quot;&quot;/\&gt;and \&lt;seeAlso cref=&quot;&quot;/\&gt;where possible.
- Always add **CDATA** tags to comments containing code and other embedded markup in order to avoid encoding issues.
- **Example:**

/// \&lt;example\&gt;

/// Add the following key to the &quot;appSettings&quot; section of your config:

/// \&lt;code\&gt;\&lt;![CDATA[

///         \&lt;configuration\&gt;

///                 \&lt;appSettings\&gt;

///                         \&lt;add key=&quot;mySetting&quot; value=&quot;myValue&quot;/\&gt;

///                 \&lt;/appSettings\&gt;

///         \&lt;/configuration\&gt;

/// ]]\&gt;\&lt;/code\&gt;

/// \&lt;/example\&gt;

- Comments example of a class:
 /// \&lt;summary\&gt;

    /// Applications workflow item object class.

    /// \&lt;/summary\&gt;

    /// \&lt;author\&gt;

    /// A.G. Rosario

    /// \&lt;/author\&gt;

    /// \&lt;remarks\&gt;

    /// Provide the functionality to manage the workflow process of an a item record from the database.

    /// \&lt;/remarks\&gt;
public class WorkflowItem

    {

                …

    }

- **Do not**** leave commented code.** Every code is in a repository so it can be consulted anytime in the future.