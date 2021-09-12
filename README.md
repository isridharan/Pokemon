# Pokemon API
1. Pokemon API is a consumption only api that helps in consuming data from https://pokeapi.co
2. No authentication is required to access this API, and all resources are fully open and available.
3. This following are endpoints exposed by Pokemon API. 

   a. GET  http://localhost:5000/pokemon/{name}
     This endpoint accepts name of the pokemon as input and returns the details of the pokemon in JSON format.  
     
           Request Parameter: name
         Request Description: Name of the resource which is pokemon
                Request Type: string
     
             Response Format:
                             {
                               "name":"mewtwo",
                               "description":"It was created by a scientist after years of horrific gene splicing and DNA engineering experiments.",
                               "habitat":"rare",
                               "isLegendary":true
                             }
 
   b. GET  http://localhost:5000/pokemon/translated/{name}
    This endpoint helps to return the details of the pokemon with translated description. If no translation is available, default description of pokemon is returned.
    
           Request Parameter: name
         Request Description: Name of the resource which is pokemon
                Request Type: string
     
             Response Format:
                             {
                               "name":"mewtwo",
                               "description":"It was created by a scientist after years of horrific gene splicing and DNA engineering experiments.",
                               "habitat":"rare",
                               "isLegendary":true
                             }
                             
4. Pokemon API is developed using ASP.Net Core 3.0 Web API and has the following exteral library dependencies.

   - AutoMapper (10.1.1) 
   - AutoMapper.Extensions.Microsoft.DependencyInjection (8.1.1)
   - Newtonsoft.Json (13.0.1)
   - RestSharp (106.12.0)
 
5. Source Pokemon Project and PokemonUnitTest project are available in the Pokemon repository.

6. Please follow the steps in Helpdoc.docx to host the API and test it.

7. Improvements planned for future are

   - Logging the Request and Response to the API.
   - Caching of requests from Pokemon API.
   - Handling Timeout from the source API.
   - Handle Scenarios when the source API is unavailable.
   - Creating Client, Service and API as different layers.
   - Versioning of the API to allow backward compatability during new releases.
