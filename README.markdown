EpubCreator
===========

Summary
-------
Creates an epub file from a collection of html files where each
html file is a chapter in the ebook.

Usage
-----
Create a folder of html files with names in the following format:
XXXX-title.html

Where XXXX is a number indicating the order of the files. So if you
have 100 blog posts you've downloaded from some blog you would name
the files from 0001 to 0100.

The title portion of the file name is used as the chapter name in
the ebook.

Run the application and enter the properties of the ebook: file name,
creator, title etc. and click 'Create'. The ebook will be created in
your 'My Documents' folder.

Configuration
-------------
The main settings (output file name, source folder etc.) are settable
in the UI of the application. Defaults for those settings as well as
the output path can be set in the .config file.

Dependencies
------------
To build the solution you will need a reference to Ionic.Zip.dll which
can be downloaded from [http://dotnetzip.codeplex.com/](http://dotnetzip.codeplex.com/).