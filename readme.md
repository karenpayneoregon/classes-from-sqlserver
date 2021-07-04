# About

Code sample to create classes from a select SQL-Server database.

![img](assets/Figure1.png)

Originally written to answer a stackoverflow [question](https://stackoverflow.com/questions/68225326/how-to-create-a-models-class-from-sql-server) to Declarate each 
property with a specific property attribute using a select statement found in `ClassQuery.txt`. Have changed to the code to exclude the property attribute using a 
query in `ClassQueryPlain.txt`

No guarantees that the code fits all situations

# Requires

- Visual Studio 2019 or higher
- NuGet package [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/)

# Important

In some cases the type for a property may not be known and in these cases will have `UNKNOWN` prepended to the SQL-Server type. In these cases a conversion will be needed.

For example [hierarchyid] needs to be parses using [SqlHierarchyId.Parse](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/ee642858(v=sql.105)?redirectedfrom=MSDN) via a read-only property.

![img](assets/unknown.png)


Base code from a [Stackoverflow post](https://stackoverflow.com/questions/5873170/generate-class-from-database-table) to a response for a [question](https://stackoverflow.com/questions/68225326/how-to-create-a-models-class-from-sql-server).

**Important** The query in ClassQuery.txt has a hard coded attribute `JsonProperty` which most likely will not be what most developers would be insterested in so you may want to modifiy the query.

To try out the code with the database setup in code, use the following [script](https://gist.github.com/karenpayneoregon/40a6e1158ff29819286a39b7f1ed1ae8).


