# NSW Transport Realtime Map

A personal project I've made to become familiar with the NSW Open Data Public Transport Realtime positioning API

## Getting Started

You will need the .NET core SDK with asp.net and C# installed.

Platforms: Linux, OSX and Windows.

### Prerequisites

See above.

### Installing

* Download this repository
* Sign up for a Google Maps and NSW Open Data publictransport API keys
* Add these keys to App.config
* dotnet restore
* dotnet build
* dotnet run

Open your favourite broswser and go to localhost:5000

## Built With

* [ASP.NET Core](https://www.asp.net/core/overview/aspnet-vnext) - The web framework used
* [.NET Core](https://dotnet.github.io) - Github page for .NET Core
* [NSW Open Data APIs](https://opendata.transport.nsw.gov.au/) - Open Data APIs that contain heaps of public transport information for NSW.
* [Google Protobufs](https://developers.google.com/protocol-buffers/) - Protocol buffers by Google. Kind of like a streamlined version of XML
* [Google GTFS](https://developers.google.com/transit/gtfs/) - A Google spec that facilitates the transfer of information for public transport networks

## Authors

* **Campbell Bartlett** - *Everything so far!*

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Change log

* 0.1 Initial Commit
This version is my first commit. If you download it and run it you will only see realtime train updates. You can change it by chaning which
of the NSW Open Data API endpoints you hit. I plan on adding a way for a user to select which services they are looking at in a future
update.
