* Bo and the Bovine
is a small little tiny app that simplifies string comparision.

** Prolem solved
Visual studio unit tests can have string output with differing strings.  
Comparing these is tedious.
This application helps a little.

** Licence
Libs are LGPL.
Application is GPLv3.

** Other
It is targeted for use with Visual Studio unit tests when a test fails and a string like
Assert.AreEqual failed. Expected:<<a href="http://example.com" target="_blank">http://example.com</a>>. Actual:<- <a href="http://example.com" target="_blank">http://example.com</a>>.
is output.  It is not difficult to parse the expected and actual strings by hand but tedious.  And boring.  Did I say tedious?