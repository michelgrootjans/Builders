#Builders
Example of using several tools to build test objects:
- FactoryGirl
- Plant

##The Challenge
Simplify the use of builders to generate test objects. Typical use:
<pre lang='csharp'>
var documentGroup = new DocumentGroupTableBuilder()
    .WithNaam("My docs")
    .WithDocumentGroupId(_documentGroupId)
    .Build();
</pre>
 
Alternative:
<pre lang='csharp'>
var documentGroup = Build
    .MeA<DocumentGroupTable>()
    .WithNaam("My docs")
    .WithDocumentGroupId(_documentGroupId)
    .Build();
</pre>
