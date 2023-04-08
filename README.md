# Weighted Graph

Desktop application for finding the shortest path in weighted graph using Dijkstra's algorithm.

## Prerequisite

* Windows
* .NET Framework 4.7.2 Runtime - [*(download)*](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-offline-installer)

## Used technologies

* .NET Framework 4.7.2
* WinForms
* File storage
* Linq to Objects
* Value Objects
* Code covered by Unit Tests
* Recursion call
* Components implement interfaces
* Dijkstra's algorithm
* Weighted graph

## Usage

### Application start

Run executable file from the root of the application *./Czu.OrientedGraph.WinApp.exe*.

### Menu

#### File

* New - new graph initialize
* Open - open existing graph
* Save - save current graph, if graph with same name already exists you will be prompted to confirm overwrite the graph
* Exit - close the application

#### Help

* View Help - see online *README.md* file
* About Application - assembly information

### Create Graph

#### Add/Update Edge

1) Fill vertices source/destination name
2) Modify edge weight
3) Click on *Add/Update* button - if edge already exists in list then the edge will be updated otherwise new one will be created

#### Remove Edge

1) Select edge in list
2) Click on *Remove* button

### Dijkstra's Algorithm

Dijkstra's algorithm is used to find shortest path through the graph.

#### Usage

1) Select vertices
   * Vertex source - start position
   * Vertex destination - end position
2) Click on *Find path* button

## Storage

Graph is stored as *.json file on disk.

### IGraphStorage interface

New storage could be implemented by interface *IGraphStorage*.

### Saved File Directory

All saved graphs are stored under application root folder *./SavedGraphs*. If folder doesn't exist then new one will be created when you saved the graph.

### Json File Structure

```json
{
    "Name": "Weighted Graph Example",
    "Edges": [
        {
            "Weight": {
                "Value": 1
            },
            "Source": {
                "Name": "A"
            },
            "Destination": {
                "Name": "B"
            }
        }
    ]
}
```