# Data Base

## Table Prefix

Database tables should have a prefix associated per module in the application. For example: SYS for system, WKF for workflow. After each prefix should have an underscore &quot;\_&quot;.

Use CODE prefix for lookup tables and CONF prefix for configuration tables.

## Table Name

After prefix is used the table name should be named using Pascal Case, were the first letter of each word is CAPITLIZED.  For example:  PEI\_WorkflowStep.

## Field Name

Each table field name should be named using Pascal Case, were the first letter of each word is CAPITLIZED.  For example:  PEI\_Student.FirstName.

## Fields Required and Order

Each table must contain the following required fields: CreatedBy, CreatedDate, UpdatedBy, Updated Date and IsDeleted. The order established for the table fields is:

1. Primary Key ID
2. Foreign Keys ID
3. Other Fields
4. Required Fields (CreatedBy, CreatedDate, etc.)


# References

The following references were used in the creation of this Coding Standards Guide.

- Encodo c Handbook
[http://archive.msdn.microsoft.com/encodocsharphandbook/Release/ProjectReleases.aspx?ReleaseId=3352](http://archive.msdn.microsoft.com/encodocsharphandbook/Release/ProjectReleases.aspx?ReleaseId=3352)
- CSharp Coding Standards
[http://weblogs.asp.net/lhunt/pages/CSharp-Coding-Standards-document.aspx](http://weblogs.asp.net/lhunt/pages/CSharp-Coding-Standards-document.aspx)
- Microsoft All-In-One Code Framework Coding Guideline
[http://1code.codeplex.com/wikipage?title=All-In-One%20Code%20Framework%20Coding%20Standards&amp;referringTitle=Documentation](http://1code.codeplex.com/wikipage?title=All-In-One%20Code%20Framework%20Coding%20Standards&amp;referringTitle=Documentation)
- c / VB.Net Coding Guidelines
[http://submain.com/blog/FreeCVBNETCodingGuidelinesEbookDownload.aspx](http://submain.com/blog/FreeCVBNETCodingGuidelinesEbookDownload.aspx)
- Top 10 Best Practices for Production ASP.NET Applications
[http://daptivate.com/archive/2008/02/12/top-10-best-practices-for-production-asp-net-applications.aspx](http://daptivate.com/archive/2008/02/12/top-10-best-practices-for-production-asp-net-applications.aspx)
- Best Practices to Improve ASP.Net Web Application Performance
[http://www.dotnetfunda.com/articles/article45.aspx](http://www.dotnetfunda.com/articles/article45.aspx)
- ASP.NET Best Practices for High Performance Applications
[http://www.codeproject.com/KB/aspnet/ASPNET\_Best\_Practices.aspx](http://www.codeproject.com/KB/aspnet/ASPNET_Best_Practices.aspx)