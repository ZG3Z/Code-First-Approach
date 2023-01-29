# Code first approach

* [Introduction](#introduction)
* [Model (ER)](#model)
* [Methods used](#methods-used)
* [Technologies used](#technologies-used)
 
 ## Introduction
 Code First Modeling creates a database that does not exist or adds new tables to an empty database.
 
 ## Model
 ![image](https://user-images.githubusercontent.com/102870734/181847016-235e26b5-582d-4753-a1b4-9d1d4a0b2675.png)
 
 ## Methods used
 * Database with sample data implemented with Entity Framework Core version.
 * GET request containing information about the specified album. Returned the JSON object contains a list of the songs on it. Album ID is assumed as a parameter. Data does not include performers who participated in creating the song. The list is sorted in ascending order by song duration. The response contains the appropriate error status.
 * DELETE request, which will allow you to delete the specified music. Music can only be removed if he participates in the creation of tracks that have not yet appeared on the target albums. In otherwise, stop processing the request and inform the user with the relevant error code. Removal is done without using cascade constraints.

 ## Technologies used
 * Web API / REST
 * DTO
 * Entity Framework Core
 * Microsoft SQL Server
