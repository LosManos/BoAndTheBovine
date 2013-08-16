# Bo and the Bovine
is a small little tiny app that simplifies string comparision.

## NOTE
I am not maintaining this project. http://approvaltests.sourceforge.net solved the problem that was the seed for this project.

## Prolem solved
Visual studio unit tests can have string output with differing strings.  
Comparing these is tedious.
This application helps a little.

## Licence
Libs are LGPL.
Application is GPLv3.

## Other
It is targeted for use with Visual Studio unit tests when a test fails and a string like
`Assert.AreEqual failed. Expected:<<a href="http://example.com" target="_blank">http://example.com</a>>. Actual:<- <a href="http://example.com" target="_blank">http://example.com</a>>`.
is output.  It is not difficult to parse the expected and actual strings by hand but tedious.  And boring.  Did I say tedious?

## Versions
1.0.0  
First numbered version.  
1.1  
Added the possibility to read files.  
1.2  
Created a more visual diff when comparing multiple lines.  
1.3  
Implemented rudimentary char code visualisation.  (#9)  
Updated the colours when comparing multiple lines.  
Changed background colouring to border colouring.  
Made it possible to do more than one multiline comparison without restart.  (#13)  
1.3.1  
Fixed readme.md (this file) formatting error.  
