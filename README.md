# Release-Note-Creator

### Motivation
When I was an intern in my first company, the changes that we did were used to be documented in the linux based system, where the changes are saved in cache (By Intersystems) database
and we had to copy those documentation in notepad and put it in the work item in the TFS as release note.

This task was tedious, repeatative and time consuming, I used to hate it and then this idea came into my mind where I wrote a program to fetch all the details of the changes (or patches)
and collect the information in file and automatically file it in the TFS as release note

### Tech Stack Used
- I used to intersystem code to fetch details of the patches documentation and then created a file out of that
- Those files are read using IO library and then it filed in TFS using TFS API (C#).
- The TFS API used to create a release note type of work item and attach it as child of a bug or a feature.

### Usefulness

This is getting used as a tool in the product team where I used to work as Intern in their day to day life. *This always motivates me when I solve small problems with my knowledge and skills*
