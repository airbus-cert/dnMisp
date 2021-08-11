[![.NET Core](https://github.com/airbus-cert/dnMisp/actions/workflows/dotnet-core.yml/badge.svg)](https://github.com/airbus-cert/dnMisp/actions/workflows/dotnet-core.yml)
[![License](https://img.shields.io/badge/License-Apache%202.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)
[![Nuget](https://img.shields.io/nuget/v/dnMisp)](https://www.nuget.org/packages/dnMisp/)

# dnMisp
***dnMisp*** is a simple, MISP Rest API consumer .Net Standard 2.0 library.

## Setup
### Package manager
`Install-Package dnMisp`

### .Net CLI
`dotnet add package dnMisp`

## Available features

The beta version is very focused on the management of IOCs, and the management & administration of organisations and users has not yet been integrated.

Here is a more detailed description of what has and has not been integrated.

### Supported
- Events: Get, Add, Update, Remove, Push to ZMQ
- Attributes: Get, Add, Update, Remove
- Tag: Add, Remove a tag
- Proposal: Add
- Add, Remove:
	- malware sample
	- hashes
	- detection link
	- detection name
	- attachments
	- reg keys
	- patterns
	- pipes
	- mutex
	- yara rules
	- threat actor
	- network activity:
		- ip dest, src
		- hostname
		- domain, domain IP
		- URIs
		- user Agents
		- traffic pattern
		- snort rules
		- ASNs
		- 'other' network activities
	- email attributes (source, destination, subject, attachment, header)
	- targeting data (email, user, machine, organization, location, external)
	- internal reference (links, comments, text, others)
	- others (comments, counters, texts)

  ### Not yet supported: 
  - galaxies & galaxy clusters
  - proposals
  - users
  - organisations
  - servers
  - feeds
  - sightings
  - warning lists
  - notice lists

  Feels free to contribute to add new or missing features !

## Compatibility 
|.NET   Standard | 2+ |
|--- | --- |
|.NET | 5+ |
|.NET   Core | 2+ |
|.NET Framework 1 | 4.6.1+ |
|Mono | 5.4+ |
|Xamarin.iOS | 10.14+ |
|Xamarin.Mac | 3.8+ |
|Xamarin.Android | 8+ |
|Universal   Windows Platform | 10.0.16299+ |
|Unity | 2018.1+ |

## Usage

### General features
How to create a new Misp consumer instance:
```csharp
MispConsumer _mispClient = MispConsumer.Create<MispConsumer>(
    YourConfig.MispUri,
    YourConfig.MispAuthKey);
```

Getting an event by its identifier:
```csharp
/* Get event by event ID */
MispEvent mispEvent = await _mispClient.GetEvent(mispEventId);
```

Download a malware sample by its hash:
```csharp
/* Download a malware by hash */
MalwareSampleList results = (await _mispClient.DownloadMalware(md5))?.Results;

if (results == null)
	return;

foreach (var item in results)
{
    string mispEventId = item.EventId;
    string base64data = item.Base64;

    // Do stuff there
}
```

Using search API:
```csharp
/* Search events */
RestSearchQuery query = new RestSearchQuery()
{
    Tags = new RestSearchOperator<string>
    {
        Or = {
            "ATT&CK:T1064:Scripting",
            "VT:attachment",
            "YARA:File_Is_Office_Open_XML"
        },
        Not =
        {
            "YARA:File_Is_Office_Doc"
        }
    },
    Limit = 10,
    Page = 1,
    Last = "5d"
};

List<MispEvent> events = await _mispClient.SearchEvent(query);
foreach (var @event in events)
{
    // Do stuff there
}
```

### Playing with attributes

Getting full attribute list from a Misp event :
```csharp
List<dnMisp.Objects.Attribute> attributes = await _mispClient.GetAttributesList(mispEventId);
```

Create Mutex attributes:
```csharp
var attr = _mispClient.CreateMutex(mispEventId, mutexName, comment: "your comment here");
```

Create Registry Key attributes:
```csharp
var attr = _mispClient.CreateRegKey(mispEventId, regKey, regValue, comment: "your comment here");
```

Then, you can upload any created attribute:
```csharp
var response = await _mispClient.AddAttribute(mispEventId, attr);
```

Removing an attribute:
```csharp
string response = await _mispClient.DeleteAttribute(int.Parse(v.Value), true);
```

### Tags

Creating new tags:
```csharp
string response = await _mispClient.AddTag(new TagRequest(new Tag("_TAG_NAME_", Color.FromArgb(254, Color.Orange), isExportable)));
```

Adding tag to a Misp Event:
```csharp
string response = await _mispClient.AddTag(mispEventId, $"_TAG_NAME_");
```

### Misp Objects

Creating malware sample Misp Object (this does not upload the sample):
```csharp
MispMalware mispObj = new MispMalware(
    fileStream, // Sample stream content
    filename,	// Filename) 
{ 
    Comment = "Powered by dnMisp" // Your comment here 
};
```

Upload a Misp object (malware sample, script, other):
```csharp
MispObjectUpload response = await _mispClient.AddObject(
    mispEventId,
    mispObj, 
    "90" // Misp Object Template ID
);
```

Removing a Misp object:
```csharp
var response = await _mispClient.RemoveObject(v);
```

## Credits
- This project is under copyright of the **Airbus CERT** and distributed under the **Apache 2.0 license**
