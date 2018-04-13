# Thoughts while developing

Detecting personal identifiable information from datasets

They list 
- Name / Surname
- Addresses
- IP Addresses
- National Insurance Numbers
- Date of Birth
- Phone Numbers
- Email Address
/// Extra things I think could be included
Social media handles? Links to facebook / twitter / instagram accounts
LinkedIn?
licence plates! 

Probably not going to do something with AI

How can I structure this well?

Thinking the above bullet points become "categories"

e.g.	name
		Address

Then each category has components

name - First, Last
Address - Postcode, Street name, Street number, flat number,


I'm thinking I should have some code that looks for the components
then have some code that compares the locations of the found components to see how likely it is they sum up to a category breach
e.g. a firstname in position x and a lastname in position x + 1 is likely to be a full name

the sample input data looks like a big table
want to run my checks on each individual cell




Break the cell into "words" by spaces
check each word to see if it's a component

What about components that are made up of components?
A postcode might have a space inbetween, E14 0SW
Or it might skip the space E140SW
So want PostCodeStart and PostCodeEnd and PostCodeWithoutSpaces components
and the address category will consider all


maybe the category - component is not complex enough

stick with components, and have aggregators that run on the set of components that are found to produce more?
and aggregators that require other aggregators?
Or the aggregators create a new component set that the next level of aggregators use



Might make sense to break cells up into sub-cells if they are really big

e.g. if it was a huge list of names then we would get a lot of first and surname components
e.g. and the cross checking of those components could be a lot faster if it's kept local
I know names/address are only important if they're close together


Full postcode is know as Postcode unit
From wikipedia postcode is 2 parts seperated by a space
first part is called outward code and second is called inwrd code

the outward code includes the postcode area and the postcode district
the inwward code includes the sector and unit
outward is between 2 and 4 characters
inward part is three

area+district (space) sector+unit
area is 1 or 2 letters
disctirc 1 or 2 digits (and sometimes a final letter)
// distric technically includes the area

second part is always 9AA
First part can be AA9A, A9A, A9, A99, AA9, AA99

so I can go with this and improve later if needed 



Matching outward and inward parts will be same as first and surname - just check for ones beside eachother
postcodes are then components in an address


or just a number detector? 
look up largest house numbers? want a house number component that flags numbers between 0 and 1000, maybe allow a letter 43a

maybe a flat component that checks for the word flat

Street names can be pretty much anything. Maybe look for words Road, Lane, Clove, Street, (and shortened versions) etc

probably want address aggregator to judge how many components are in a 3-5, 6 range?


could have an aggregator verifier / enhancer / checker?
Do a google lookup on addresses



Date of birth
Mmmm, simple one would just look for words that are parsable as dates

can definetly restrict to dates in that last 100 years? Less likely to be a date of birth if within the last 18 years


Names... on aggregator we could flag firstnames that match the firstname of a firstname-surname pair



Dataset of names
https://data.gov.uk/dataset/baby_names_england_and_wales




My component model seems a little restrictive on adding extra data
If I do a link component, I've parsed the string to a Uri already but it is not saved. And the facebook and twitter aggregators would have to reparse to work out the domain
Linkedin 

F# type system may suit this better



AggregateComponents maybe wrong name? True for names and addresses
But e.g. I have a link detector component
and I want to inspect the link to see if it's a facebook profile... 

ComponentInpector?

Is the output of a component inspector available to other inspectors?
No, not to component inspectors
maybe the inspectors should have a severity level as an output



Might be worth checking if it's better for words to contain their lowercase versions. 
Since both first and surname detectors are going to be calling .ToLower for their comparisions, save time doing it earlier

The loop in the Process can probably be made parallel, 



should look for a dataset of uk town and city names
and counties

highest street number in britian is 
2679 stratford road, hockley health, solihull B94 5NH
// 8 address width? 10?


Going to want to write some documentation
code should hopefully be well-written enough to be self-documenting

The input for the program is a csv datafile, and an optional configuration json blob
the configration blob contains settings for which categories of PII you are looking for

Data in a PII category can generally by thought of as made up of seperate components
e.g. a full name contains a first and a surname
e.g. An address might have a house number, street, town, county, postcode
some can be thought of as a single component such as IPAddress
some categories share components
some components can be made slightly generic to be of use to multiple categories

Generally a single component by itself is not PII

A group of components can be inspected to see if they look like a full category


This processor works by turning the configued set of categories into a list of ComponentInspectors (can be thought of as category finders)
Each inspector lists the component types its interested in
With the distinct list of component types we can construct ComponentDetectors for each type

we then break the input up into it's rows and columns (into cells)
each cell is then split up into words
The words of a cell are put through the detectors to pick out components
the components are put through the inspectors to find categories
the results for each cell are added together and for a set of SearchResults

The search results are then mapped to the expected JSON output format
and saved beside the input


Could maybe add a verifier layer after the inspectors
which does things like check google maps for the address
pings an IP address
Facebook searches names 


Postcode regex