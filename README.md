# Lintol Challenge 1

## Introduction
The input for the program is a csv datafile and some configuration.
the configration contains settings for which categories of PII you are looking for.

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

## Input
### Data
The input data file is expected to be a csv named "input.csv" inside the /data/ folder where the program is running.
### Configuration
The configuration file is called "config.json" and sits beside the input data file. Categories can be turned off/on by removing them from the json property of the same name. The output json can be made lighter by turning information off.

```json
{
	"categories": [
		"CommonFullName",
		"PossibleFullName",
		"SocialMediaLink",
		"EmailAddress",
		"DateOfBirth",
		"ValidIpAddress",
		"Address"
	],
	"includeInformationInOutput": false,
	"useVerifiers":  false 
}
```

## Verifiers
The intention behind the verifier layer is online / 3rd party verification of information detected by the inspectors.
A proof of concept in included that does a facebook search for possible fullnames to see if anyone has a profile with that name.
Possible first names are detected as pairs of words in the input that aren't found in the dictionary dataset.

The ability to turn verifiers off though the config is added as external searches can take some time and require an internet connection.
