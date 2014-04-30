Builders
========

Example of using several tools to build test objects:
- FactoryGirl
- Plant

The Challenge
-------------

Simplify the use of builders to generate test objects. Typical use: 
    var documentGroup = new DocumentGroupTableBuilder()
        .WithNaam("My docs")
        .WithDocumentGroupId(_documentGroupId)
        .Build();
 
 
Alternative:
 	var documentGroup = Build
	    .MeA<DocumentGroupTable>()
	    .WithNaam("My docs")
	    .WithDocumentGroupId(_documentGroupId)
	    .Build();
