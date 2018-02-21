# NSW Public Transport Live Updates

A personal project I've been tinkering with to explore the NSW Public transport open API.

It shows the position of all trains, ferries or busses in Sydney in real time, updating every 5 seconds

## Getting Started

You will need the .NET core SDK with asp.net and C# installed.

Platforms: Linux, OSX and Windows.

### Prerequisites

See above.

### Installing

* Download this repository
* Configure your NSW Open Data API key and GoogleMaps API keys in App.Config
* dotnet restore
* dotnet build
* dotnet run

Open your favourite broswser and go to localhost:5001

## Built With

* [ASP.NET Core](https://www.asp.net/core/overview/aspnet-vnext) - The web framework used
* [.NET Core](https://dotnet.github.io) - Github page for .NET Core
* [NSW Open API for Public Transport](https://opendata.transport.nsw.gov.au/) - The API where I get the data
* [Google Protobufs](https://github.com/google/protobuf) - A protocol for transferring data, similar to XML but more streamlined.
* [Google GTSF Protocol](https://developers.google.com/transit/gtfs/) - A specification for a common format for publishing tansportation schedules.

## Authors

* **Campbell Bartlett** - *Everything so far!*

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Change log

* 0.1 Initial commit.
